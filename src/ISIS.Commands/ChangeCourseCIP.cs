using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Course), "ChangeCIP")]
    public class ChangeCourseCIP : CommandBase 
    {
        [AggregateRootId]
        public Guid CourseId { get; private set; }

        public string CIP { get; private set; }

        public ChangeCourseCIP(Guid courseId, string cip)
        {
            CourseId = courseId;
            CIP = cip;
        }
    }
}
