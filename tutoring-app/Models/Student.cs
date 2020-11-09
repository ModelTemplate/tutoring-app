using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutoring_app.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int phone { get; set; }
        public int email { get; set; }
    }
}
