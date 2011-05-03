using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{
    public class CreateCourse : CommandBase 
    {
        public Guid CourseId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }
        public string Title { get; private set; }

        public CreateCourse(Guid courseId, string rubric, string courseNumber, string title)
        {
            CourseId = courseId;
            Rubric = rubric;
            CourseNumber = courseNumber;
            Title = title;
        }


    }
}
