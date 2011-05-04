using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class CreateCourse : CommandBase 
    {
        public Guid CourseId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }

        public CreateCourse(Guid courseId, string rubric, string courseNumber)
        {
            CourseId = courseId;
            Rubric = rubric;
            CourseNumber = courseNumber;
        }


    }
}
