using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootConstructor(typeof(Course))]
    public class CreateCourse : CommandBase 
    {
        [CreateAggregateWithId]
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
