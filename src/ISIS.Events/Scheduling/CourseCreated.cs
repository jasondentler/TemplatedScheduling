using System;

namespace ISIS.Scheduling
{
    public class CourseCreated
    {

        public Guid CourseId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }
        public bool IsContinuingEducation { get; private set; }

        public CourseCreated(Guid courseId, string rubric, string courseNumber, bool isContinuingEducation)
        {
            CourseId = courseId;
            Rubric = rubric;
            CourseNumber = courseNumber;
            IsContinuingEducation = isContinuingEducation;
        }
    }
}
