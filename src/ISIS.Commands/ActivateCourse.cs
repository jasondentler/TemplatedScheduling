using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Course), "Activate")]
    public class ActivateCourse : CommandBase 
    {
        [AggregateRootId]
        public Guid CourseId { get; private set; }

        public ActivateCourse(Guid courseId)
        {
            CourseId = courseId;
        }


    }
}
