using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Course), "ChangeDescription")]
    public class ChangeCourseDescription : CommandBase 
    {
        [AggregateRootId]
        public Guid CourseId { get; private set; }

        public string Description { get; private set; }

        public ChangeCourseDescription(Guid courseId, string description)
        {
            CourseId = courseId;
            Description = description;
        }
    }
}
