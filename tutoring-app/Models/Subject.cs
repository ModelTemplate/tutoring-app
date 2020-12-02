using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tutoring_app.Models
{
    /// <summary>
    /// Represents an academic subject
    /// </summary>
    public class Subject
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
