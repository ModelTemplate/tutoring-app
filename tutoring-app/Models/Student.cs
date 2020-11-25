using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutoring_app.Models
{
    /// <summary>
    /// Represents a student user
    /// </summary>
    public class Student : User
    {
        public string Grade { get; set; }
    }
}
