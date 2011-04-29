using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Course), "ChangeTitle")]
    public class ChangeCourseTitle : CommandBase 
    {
        [AggregateRootId]
        public Guid CourseId { get; private set; }

        public string NewTitle { get; private set; }

        public ChangeCourseTitle(Guid courseId, string newTitle)
        {
            CourseId = courseId;
            NewTitle = newTitle;
        }


    }
}
