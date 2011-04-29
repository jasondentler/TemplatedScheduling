using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Course), "MakeObsolete")]
    public class MakeCourseObsolete : CommandBase 
    {
        [AggregateRootId]
        public Guid CourseId { get; private set; }

        public MakeCourseObsolete(Guid courseId)
        {
            CourseId = courseId;
        }


    }
}
