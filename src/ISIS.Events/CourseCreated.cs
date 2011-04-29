using System;

namespace ISIS.Events
{
    public class CourseCreated
    {

        public Guid CourseId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }
        public string Title { get; private set; }

        public CourseCreated(Guid courseId, string rubric, string courseNumber, string title)
        {
            CourseId = courseId;
            Rubric = rubric;
            CourseNumber = courseNumber;
            Title = title;
        }
    }
}
