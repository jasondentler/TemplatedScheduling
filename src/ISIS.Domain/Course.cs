using System;
using Ncqrs.Domain;

namespace ISIS.Domain
{
    public class Course : AggregateRootMappedByConvention 
    {

        public Course(Guid courseId, string rubric, string courseNumber, string title)
        {
        }

    }
}
