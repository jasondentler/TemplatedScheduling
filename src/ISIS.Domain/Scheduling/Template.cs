using System;
using ISIS.Scheduling.ActivateTemplateExceptions;
using ISIS.Scheduling.CopyTemplateExceptions;
using ISIS.Scheduling.CreateTemplateExceptions;
using ISIS.Scheduling.TermAssignedToTemplateExceptions;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{
    public class Template : AggregateRootMappedByConvention
    {

        private TemplateStatuses _status;
        private string _label;
        private bool _isContinuingEducation;
        private Guid _courseId;
        private string _rubric;
        private string _courseNumber;
        private string _title;
        private string _description;
        private Guid _termId;

        private Template()
        {
        }

        public Template(Guid templateId, string newLabel, Course course)
            : base(templateId)
        {
            var courseData = course.GetCourseData();

            if (string.IsNullOrEmpty(courseData.Title))
                throw new CourseMissingTitleException();
            
            if (string.IsNullOrEmpty(courseData.Description))
                throw new CourseMissingDescriptionException();

            var @event = new TemplateCreated(
                EventSourceId,
                newLabel,
                courseData.CourseId,
                courseData.Rubric,
                courseData.CourseNumber,
                courseData.Title,
                courseData.Description,
                courseData.IsContinuingEducation);
            ApplyEvent(@event);
        }

        public Template(Guid templateId, string newLabel, TemplateData sourceData, Term term, Course course)
            : this(templateId, newLabel, course)
        {
            if (sourceData.Status == TemplateStatuses.Obsolete)
                throw new SourceTemplateObsoleteException();

            AssignTerm(term);

            switch (sourceData.Status)
            {
                case TemplateStatuses.Pending:
                    // Pending by default
                    break;
                case TemplateStatuses.Obsolete:
                    MakeObsolete();
                    break;
                case TemplateStatuses.Deactivated:
                    Deactivate();
                    break;
                case TemplateStatuses.Activated:
                    Activate();
                    break;
            }

            var @event = new TemplateCopied(
                EventSourceId, newLabel, sourceData.TemplateId, sourceData.Label);
            ApplyEvent(@event);
        }

        public TemplateData GetTemplateData()
        {
            return new TemplateData()
            {
                TemplateId = EventSourceId,
                Label = _label,
                CourseId = _courseId,
                TermId = _termId,
                Rubric = _rubric,
                CourseNumber = _courseNumber,
                Title = _title,
                Description = _description,
                IsContinuingEducation = _isContinuingEducation,
                Status = _status
            };
        }

        public void Rename(string newLabel)
        {
            if (_label != newLabel)
                ApplyEvent(new TemplateRenamed(EventSourceId, _label, newLabel));
        }

        public void Activate()
        {
            if (_termId == default(Guid))
                throw new TemplateMissingTermException();

            if (_status != TemplateStatuses.Activated)
                ApplyEvent(new TemplateActivated(EventSourceId));
        }

        public void MakePending()
        {
            if (_status != TemplateStatuses.Pending)
                ApplyEvent(new TemplateMadePending(EventSourceId));
        }

        public void Deactivate()
        {
            if (_status != TemplateStatuses.Deactivated)
                ApplyEvent(new TemplateDeactivated(EventSourceId));
        }

        public void MakeObsolete()
        {
            if (_status != TemplateStatuses.Obsolete)
                ApplyEvent(new TemplateMadeObsolete(EventSourceId));
        }

        public void AssignTerm(Term term)
        {
            var termData = term.GetTermData();

            if (!_isContinuingEducation && termData.IsContinuingEducation)
                throw new TermIsContinuingEducationException();

            if (_isContinuingEducation && !termData.IsContinuingEducation)
                throw new TermIsNotContinuingEducationException();

            var @event =
                _isContinuingEducation
                    ? new TermAssignedToTemplate(EventSourceId, termData.TermId, termData.Name)
                    : new TermAssignedToTemplate(EventSourceId, termData.TermId, termData.Name, termData.StartDate,
                                                 termData.EndDate);
            ApplyEvent(@event);
        }
        
        protected void On(TemplateCreated @event)
        {
            _label = @event.Label;
            _courseId = @event.CourseId;
            _rubric = @event.Rubric;
            _courseNumber = @event.CourseNumber;
            _title = @event.Title;
            _description = @event.Description;
            _isContinuingEducation = @event.IsContinuingEducation;
        }

        protected void On(TemplateRenamed @event)
        {
            _label = @event.NewLabel;
        }

        protected void On(TemplateActivated @event)
        {
            _status = TemplateStatuses.Activated;
        }

        protected void On(TemplateMadePending @event)
        {
            _status = TemplateStatuses.Pending;
        }

        protected void On(TemplateDeactivated @event)
        {
            _status = TemplateStatuses.Deactivated;
        }

        protected void On(TemplateMadeObsolete @event)
        {
            _status = TemplateStatuses.Obsolete;
        }

        protected void On(TermAssignedToTemplate @event)
        {
            _termId = @event.TermId;
        }

        protected void On(TemplateCopied @event)
        {
        }

    }
}
