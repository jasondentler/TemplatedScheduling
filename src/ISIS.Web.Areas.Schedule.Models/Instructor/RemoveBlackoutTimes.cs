using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISIS.Web.Areas.Schedule.Models.Instructor
{
    public class RemoveBlackoutTimes
    {

        public Guid Id { get; set; }
        public Guid[] BlackoutTimeIds { get; set; }

    }
}
