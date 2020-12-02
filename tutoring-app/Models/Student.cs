using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using tutoring_app.Areas.Identity;

namespace tutoring_app.Models
{
    /// <summary>
    /// Represents a student user
    /// </summary>
    public class Student : ApplicationUser
    {
        [ForeignKey("Id")]
        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Grade { get; set; }
    }
}
