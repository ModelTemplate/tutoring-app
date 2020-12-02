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
            string qouteString = "";
            string qouteAuthor = "";
            HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetStringAsync("https://api.quotable.io/random");

                if (string.IsNullOrEmpty(response))
                {
                    Debug.WriteLine("Failed to receive response from the quote api");
                }

                QuoteApiModel qoute = Newtonsoft.Json.JsonConvert.DeserializeObject<QuoteApiModel>(response);
                if(qoute != null)
                {
                    qouteString = qoute.content;
                    qouteAuthor = qoute.author;
                }
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }

            ViewData["QouteString"] = qouteString;
            ViewData["QouteAuthor"] = qouteAuthor;

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
