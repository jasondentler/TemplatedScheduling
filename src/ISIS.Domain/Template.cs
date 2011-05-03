using System;
using ISIS.Events;
using Ncqrs.Domain;

namespace ISIS.Domain
{
    public class Template : AggregateRootMappedByConvention
    {

        private CourseStatuses _status;
        private string _label;
        private CourseTypes _courseType;
        private CreditTypes _creditType;
        private bool _isContinuingEducation;

        private Template()
        {
        }

        public Template(Guid templateId, string label, Course course)
            : base(templateId)
        {
            var courseData = course.GetCourseData();

            if (string.IsNullOrEmpty(courseData.Title))
                throw new CourseMissingTitleException();

            if (string.IsNullOrEmpty(courseData.CIP))
                throw new CourseMissingCIPException();

            if (string.IsNullOrEmpty(courseData.Description))
                throw new CourseMissingDescriptionException();

            var @event = new TemplateCreated(
                EventSourceId,
                label,
                courseData.CourseId,
                courseData.Rubric,
                courseData.CourseNumber,
                courseData.Title,
                courseData.CIP,
                courseData.Description,
                courseData.IsContinuingEducation);
            ApplyEvent(@event);
        }

        public void Rename(string newLabel)
        {
            if (_label != newLabel)
                ApplyEvent(new TemplateRenamed(EventSourceId, _label, newLabel));
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

        public void ChangeCreditType(CreditTypes creditType)
        {
            if (_creditType == creditType)
                return;

            if (!_isContinuingEducation)
                throw new CourseIsNotCEException();

            switch (creditType)
            {
                case CreditTypes.ContractTrainingFunded:
                case CreditTypes.GrantFunded:
                case CreditTypes.WorkforceFunded:
                    ApplyEvent(new TemplateCreditTypeChanged(EventSourceId, creditType));
                    if (_courseType != CourseTypes.CWECM)
                        ApplyEvent(new TemplateCourseTypeChanged(EventSourceId, CourseTypes.CWECM));
                    break;
                default:
                    ApplyEvent(new TemplateCreditTypeChanged(EventSourceId, creditType));
                    if (_courseType != CourseTypes.CE)
                        ApplyEvent(new TemplateCourseTypeChanged(EventSourceId, CourseTypes.CE));
                    break;
            }
        }


        protected void On(TemplateCreated @event)
        {
            _label = @event.Label;
            _isContinuingEducation = @event.IsContinuingEducation;
        }

        protected void On(TemplateRenamed @event)
        {
            _label = @event.NewLabel;
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

        protected void On(TemplateCreditTypeChanged @event)
        {
            _creditType = @event.CreditType;
        }

        protected void On(TemplateCourseTypeChanged @event)
        {
            _courseType = @event.CourseType;
        }

    }
}
