using System;

namespace ISIS.Web.Areas.Schedule.Models
{
    public class CalendarItem
    {

        public Guid Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Class { get; set; }

    }
}
