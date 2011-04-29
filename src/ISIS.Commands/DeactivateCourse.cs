using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Course), "Deactivate")]
    public class DeactivateCourse : CommandBase 
    {
        [AggregateRootId]
        public Guid CourseId { get; private set; }

        public DeactivateCourse(Guid courseId)
        {
            CourseId = courseId;
        }


    }
}
