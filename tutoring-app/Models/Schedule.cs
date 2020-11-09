using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutoring_app.Models
{
    public class Schedule
    {
        public string ScheduleID { get; set; }
        public int Time { get; set; }
        public int Date { get; set; }
        public string Day { get; set; }
    }
}
