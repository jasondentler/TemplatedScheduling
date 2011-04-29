using System;

namespace ISIS.Events
{
    public class CourseMadeObsolete
    {

        public Guid CourseId { get; private set; }

        public CourseMadeObsolete(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
