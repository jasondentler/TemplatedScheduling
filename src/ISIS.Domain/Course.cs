using System;
using ISIS.Events;
using Ncqrs.Domain;

namespace ISIS.Domain
{
    public class Course : AggregateRootMappedByConvention
    {

        public enum CourseStatuses
        {
            Pending = 0,
            Activated = 1,
            Deactivated = 2,
        }

        private string _title;
        private string _cip;
        private string _description;
        private CourseStatuses _status;

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
            if (_title != newTitle)
                ApplyEvent(new CourseTitleChanged(
                               EventSourceId,
                               _title,
                               newTitle));
        }

        public void ChangeCIP(string cip)
        {
            if (_cip != cip)
                ApplyEvent(new CourseCIPChanged(
                               EventSourceId,
                               _cip,
                               cip));
        }

        public void ChangeDescription(string description)
        {
            if (_description != description)
                ApplyEvent(new CourseDescriptionChanged(
                               EventSourceId,
                               _description,
                               description));
        }

        public void Activate()
        {
            if (string.IsNullOrEmpty(_cip))
                throw new CourseMissingCIPException();
            
            if (string.IsNullOrEmpty(_description))
                throw new CourseMissingDescriptionException();

            if (_status != CourseStatuses.Activated)
                ApplyEvent(new CourseActivated(EventSourceId));
        }

        public void MakePending()
        {
            if (_status != CourseStatuses.Pending)
                ApplyEvent(new CourseMadePending(EventSourceId));
        }

        protected void On(CourseCreated @event)
        {
            _title = @event.Title;
        }

        protected void On(CourseTitleChanged @event)
        {
            _title = @event.NewTitle;
        }

        protected void On(CourseCIPChanged @event)
        {
            _cip = @event.NewCIP;
        }

        protected void On(CourseDescriptionChanged @event)
        {
            _description = @event.NewDescription;
        }

        protected void On(CourseActivated @event)
        {
            _status = CourseStatuses.Activated;
        }

        protected void On(CourseMadePending @event)
        {
            _status = CourseStatuses.Pending;
        }

    }
}
