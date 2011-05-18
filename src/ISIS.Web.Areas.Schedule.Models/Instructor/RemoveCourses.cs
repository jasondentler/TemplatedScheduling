using System;

namespace ISIS.Web.Areas.Schedule.Models.Instructor
{
    public class RemoveCourses
    {

        public Guid Id { get; set; }
        public Guid[] CourseIds { get; set; }

    }
}
