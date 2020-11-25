using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutoring_app.Models
{
    /// <summary>
    /// Represents a tutoring schedule between a student and a tutor
    /// </summary>
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Student Student { get; set; }
        public Tutor Tutor { get; set; }
        public Subject Subject { get; set; }
    }
}
