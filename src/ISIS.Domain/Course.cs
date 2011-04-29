using System;
using ISIS.Events;
using Ncqrs.Domain;

namespace ISIS.Domain
{
    public class Course : AggregateRootMappedByConvention 
    {

        public Course(Guid courseId, string rubric, string courseNumber, string title)
            : base(courseId)
        {
            ApplyEvent(new CourseCreated(courseId, rubric, courseNumber, title));
        }


        protected void On(CourseCreated @event)
        {
        }

    }
}
