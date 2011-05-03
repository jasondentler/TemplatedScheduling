using System;
using ISIS.Events;
using Ncqrs.Domain;

namespace ISIS.Domain
{
    public class Template : AggregateRootMappedByConvention
    {

        private CourseStatuses _status;
        private string _cip;
        private string _description;

        private Template()
        {
        }

        public Template(Guid templateId, Course course)
            : base(templateId)
        {
            var courseData = course.GetCourseData();

            if (string.IsNullOrEmpty(courseData.CIP))
                throw new CourseMissingCIPException();

            if (string.IsNullOrEmpty(courseData.Description))
                throw new CourseMissingDescriptionException();
            
            var @event = new TemplateCreated(
                EventSourceId,
                courseData.CourseId,
                courseData.Rubric,
                courseData.CourseNumber,
                courseData.Title,
                courseData.CIP,
                courseData.Description);
            ApplyEvent(@event);
        }


        public void Activate()
        {
            if (_status != CourseStatuses.Activated)
                ApplyEvent(new TemplateActivated(EventSourceId));
        }

        public void MakePending()
        {
            if (_status != CourseStatuses.Pending)
                ApplyEvent(new TemplateMadePending(EventSourceId));
        }

        public void Deactivate()
        {
            if (_status != CourseStatuses.Deactivated)
                ApplyEvent(new TemplateDeactivated(EventSourceId));
        }

        public void MakeObsolete()
        {
            if (_status != CourseStatuses.Obsolete)
                ApplyEvent(new TemplateMadeObsolete(EventSourceId));
        }

        protected void On(TemplateCreated @event)
        {
        }

        protected void On(TemplateActivated @event)
        {
            _status = CourseStatuses.Activated;
        }

        protected void On(TemplateMadePending @event)
        {
            _status = CourseStatuses.Pending;
        }

        protected void On(TemplateDeactivated @event)
        {
            _status = CourseStatuses.Deactivated;
        }

        protected void On(TemplateMadeObsolete @event)
        {
            _status = CourseStatuses.Obsolete;
        }


    }
}
