using System;
using ISIS.Events;
using Ncqrs.Domain;

namespace ISIS.Domain
{
    public class Course : AggregateRootMappedByConvention
    {

        private string _title;

        private Course()
        {
        }
        
        public Course(Guid courseId, string rubric, string courseNumber, string title)
            : base(courseId)
        {
            ApplyEvent(new CourseCreated(EventSourceId, rubric, courseNumber, title));
        }


        public void ChangeTitle(string newTitle)
        {
            ApplyEvent(new CourseTitleChanged(
                           EventSourceId,
                           _title,
                           newTitle));
        }

        protected void On(CourseCreated @event)
        {
            _title = @event.Title;
        }

        protected void On(CourseTitleChanged @event)
        {
            _title = @event.NewTitle;
        }

    }
}
