using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutoring_app.Models
{
    public class QuoteApiModel
    {
            public string _id { get; set; }
            public string[] tags { get; set; }
            public string content { get; set; }
            public string author { get; set; }
            public int length { get; set; }
    }
}
