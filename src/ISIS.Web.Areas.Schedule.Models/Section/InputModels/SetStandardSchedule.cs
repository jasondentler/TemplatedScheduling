using System;

namespace ISIS.Web.Areas.Schedule.Models.Section.InputModels
{
    public class SetStandardSchedule
    {

        public Guid Id { get; set; }
        public string Days { get; set; }
        public string Time { get; set; }

    }
}
