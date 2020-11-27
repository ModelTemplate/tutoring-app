using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tutoring_app.Models
{
    /// <summary>
    /// Represents a tutoring schedule between a student and a tutor
    /// </summary>
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Id")]
        public Student Student { get; set; }

        [ForeignKey("Id")]
        public Tutor Tutor { get; set; }

        [ForeignKey("Id")]
        public Subject Subject { get; set; }
    }
}
