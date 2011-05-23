using System;
using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Schedule.Models.Instructor
{
    public class Calendar : JsonSerializable 
    {
        public Calendar(
            Guid id,
            string title,
            IEnumerable<CalendarItem> items)
        {
            Id = id;
            Name = title;
            Items = items;
            Start = new DateTime(2011, 5, 8);
            End = Start.AddDays(7).AddTicks(-1);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CalendarItem> Items { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
