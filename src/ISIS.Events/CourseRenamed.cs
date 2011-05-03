using System;

namespace ISIS.Events
{
    public class CourseRenamed
    {

        public Guid CourseId { get; private set; }
        public string OldTitle { get; private set; }
        public string NewTitle { get; private set; }
        public string OldShortTitle { get; private set; }
        public string NewShortTitle { get; private set; }

        public CourseRenamed(Guid courseId, 
            string oldTitle, string newTitle,
            string oldShortTitle, string newShortTitle)
        {
            CourseId = courseId;
            OldTitle = oldTitle;
            NewTitle = newTitle;
            OldShortTitle = oldShortTitle;
            NewShortTitle = newShortTitle;
        }

    }
}
