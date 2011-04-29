using System;

namespace ISIS.Events
{
    public class CourseTitleChanged
    {

        public Guid CourseId { get; private set; }
        public string OldTitle { get; private set; }
        public string NewTitle { get; private set; }

        public CourseTitleChanged(Guid courseId, string oldTitle, string newTitle)
        {
            CourseId = courseId;
            OldTitle = oldTitle;
            NewTitle = newTitle;
        }

    }
}
