using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutoring_app.Models
{
    /// <summary>
    /// Represents an academic subject
    /// </summary>
    public class Subject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
    }
}
