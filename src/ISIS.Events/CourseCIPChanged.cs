using System;

namespace ISIS.Events
{
    public class CourseCIPChanged
    {

        public Guid CourseId { get; private set; }
        public string OldCIP { get; private set; }
        public string NewCIP { get; private set; }

        public CourseCIPChanged(Guid courseId, string oldCIP, string newCIP)
        {
            CourseId = courseId;
            OldCIP = oldCIP;
            NewCIP = newCIP;
        }

    }
}
