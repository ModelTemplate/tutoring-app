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
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
