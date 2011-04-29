using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Course), "MakePending")]
    public class MakeCoursePending : CommandBase 
    {
        [AggregateRootId]
        public Guid CourseId { get; private set; }

        public MakeCoursePending(Guid courseId)
        {
            CourseId = courseId;
        }


    }
}
