using System;

namespace ISIS.Web.Areas.Schedule.Models.Section.InputModels
{
    public class SetNonstandardSchedule
    {

        public Guid Id { get; set; }
        public string[] Days { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

    }
}
