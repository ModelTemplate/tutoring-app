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
        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }  // grade level (e.g. Calculus 1 vs. Calculus 2)
        public string Description { get; set; }
        public string SubjectInfo() { return Name + " " + Level; } //created for UnitTesting
    }
}
