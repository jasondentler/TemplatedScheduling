using System;

namespace ISIS.Web.Areas.Schedule.Models.Instructor.InputModels
{
    public class RemoveCourses
    {

        public Guid Id { get; set; }
        public Guid[] CourseIds { get; set; }

    }
}
