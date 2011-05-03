using System;

namespace ISIS.Events
{
    public class CourseCreated
    {

        public Guid CourseId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }

        public CourseCreated(Guid courseId, string rubric, string courseNumber)
        {
            CourseId = courseId;
            Rubric = rubric;
            CourseNumber = courseNumber;
        }
    }
}
