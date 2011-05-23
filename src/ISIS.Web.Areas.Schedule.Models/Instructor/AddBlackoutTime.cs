using System;

namespace ISIS.Web.Areas.Schedule.Models.Instructor
{
    public class AddBlackoutTime
    {

        public Guid Id { get; set; }
        public DayOfWeek DayOfTheWeek { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
