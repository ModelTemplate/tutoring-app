using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tutoring_app.Models;

namespace tutoring_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string quoteString = "";
            string quoteAuthor = "";
            HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetStringAsync("https://api.quotable.io/random");

                if (string.IsNullOrEmpty(response))
                {
                    Debug.WriteLine("Failed to receive response from the Quote API.");
                }

                QuoteApiModel quote = Newtonsoft.Json.JsonConvert.DeserializeObject<QuoteApiModel>(response);
                
                if(quote != null)
                {
                    quoteString = quote.Content;
                    quoteAuthor = quote.Author;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }

            ViewData["QuoteString"] = quoteString;
            ViewData["QuoteAuthor"] = quoteAuthor;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
