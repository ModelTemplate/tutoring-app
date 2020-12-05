using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutoring_app.Models
{
    /// <summary>
    /// Using external API to generate quotes
    /// </summary>
    public class QuoteApiModel
    {
            public string Id { get; set; }
            public string[] Tags { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
            public int Length { get; set; }
            
            public string QuoteApiModelInfo() { return Author + " " + Content; }
    }
}
