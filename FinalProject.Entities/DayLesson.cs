using System;
using System.Collections.Generic;

namespace FinalProject.Entities
{
    public class DayLesson
    {
        public int ID { get; set; }

        public IEnumerable<DateTime> TimeLesson { get; set; }

        public DateTime Day_Lesson { get; set; }
    }
}
