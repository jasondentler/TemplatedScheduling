using System;

namespace ISIS.Events
{
    public class CourseMadePending
    {

        public Guid CourseId { get; private set; }

        public CourseMadePending(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
