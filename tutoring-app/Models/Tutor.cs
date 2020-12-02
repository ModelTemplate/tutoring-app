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
    /// Represents a tutor user
    /// </summary>
    public class Tutor : ApplicationUser
    {
        [ForeignKey("Id")]
        [Required]
        public virtual ApplicationUser User { get; set; }

        // [Required]
        // public List<Subject> QualifiedSubjects { get; set; }
    }
}
