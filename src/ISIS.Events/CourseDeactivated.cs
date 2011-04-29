using System;

namespace ISIS.Events
{
    public class CourseDeactivated
    {

        public Guid CourseId { get; private set; }

        public CourseDeactivated(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
