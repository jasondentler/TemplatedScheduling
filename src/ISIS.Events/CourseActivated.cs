using System;

namespace ISIS.Events
{
    public class CourseActivated
    {

        public Guid CourseId { get; private set; }

        public CourseActivated(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
