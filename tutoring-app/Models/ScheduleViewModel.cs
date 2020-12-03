using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutoring_app.Models
{
    /// <summary>
    /// View model for scheduling a meeting
    /// </summary>
    public class ScheduleViewModel
    {
        public DateTime Date { get; set; }
        public Student Student { get; set; }
        public Tutor Tutor { get; set; }
    }
}
