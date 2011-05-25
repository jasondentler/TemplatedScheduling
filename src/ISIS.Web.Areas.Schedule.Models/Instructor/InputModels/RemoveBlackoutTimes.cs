using System;

namespace ISIS.Web.Areas.Schedule.Models.Instructor.InputModels
{
    public class RemoveBlackoutTimes
    {

        public Guid Id { get; set; }
        public Guid[] BlackoutTimeIds { get; set; }

    }
}
