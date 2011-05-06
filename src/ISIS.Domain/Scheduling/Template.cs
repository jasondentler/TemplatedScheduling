using System;
using System.Collections.Generic;
using ISIS.Scheduling.ActivateTemplateExceptions;
using ISIS.Scheduling.CopyTemplateExceptions;
using ISIS.Scheduling.CreateTemplateExceptions;
using ISIS.Scheduling.RemoveTemplateStudentEquipmentException;
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
        private Guid _instructorId;
        private readonly Dictionary<string, int> _instructorEquipment = new Dictionary<string, int>();
        private readonly Dictionary<string, StudentEquipmentQuantity> _studentEquipment =
            new Dictionary<string, StudentEquipmentQuantity>();

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

            foreach (var item in courseData.InstructorEquipment)
                AddInstructorEquipment(item.Value, item.Key);

            foreach (var item in courseData.StudentEquipment)
                AddStudentEquipment(item.Value.Quantity, item.Value.PerStudent, item.Key);
        }

        public Template(Guid templateId, string newLabel, TemplateData sourceData, Term term, Course course, Instructor instructor)
            : this(templateId, newLabel, course)
        {
            if (term == null) throw new ArgumentNullException("term");
            if (course == null) throw new ArgumentNullException("course");

            if (instructor != null && instructor.EventSourceId != sourceData.InstructorId)
                throw new ApplicationException("The instructor object provided doesn't match the source template data.");

            if (term.EventSourceId != sourceData.TermId)
                throw new ApplicationException("The term object provided doesn't match the source template data.");

            if (course.EventSourceId != sourceData.CourseId)
                throw new ApplicationException("The course object provided doesn't match the source template data.");
            
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

            if (instructor != null)
                AssignInstructor(instructor);

            foreach (var item in sourceData.InstructorEquipment)
                AddInstructorEquipment(item.Value, item.Key);

            foreach (var item in sourceData.StudentEquipment)
                AddStudentEquipment(item.Value.Quantity, item.Value.PerStudent, item.Key);


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
                           InstructorId = _instructorId,
                           Rubric = _rubric,
                           CourseNumber = _courseNumber,
                           Title = _title,
                           Description = _description,
                           IsContinuingEducation = _isContinuingEducation,
                           Status = _status,
                           InstructorEquipment = new Dictionary<string, int>(_instructorEquipment),
                           StudentEquipment = new Dictionary<string, StudentEquipmentQuantity>(_studentEquipment)
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

        public void AssignInstructor(Instructor instructor)
        {
            if (instructor.EventSourceId == _instructorId) return;

            var instructorData = instructor.GetInstructorData();
            var @event = new InstructorAssignedToTemplate(
                instructorData.InstructorId,
                instructorData.FirstName,
                instructorData.LastName,
                EventSourceId,
                _label);
            ApplyEvent(@event);
        }

        public void UnassignInstructor()
        {
            if (_instructorId == default(Guid)) return;

            var @event = new InstructorUnassignedFromTemplate(
                _instructorId, EventSourceId, _label);
            ApplyEvent(@event);
        }


        public void AddInstructorEquipment(int quantity, string equipmentName)
        {
            var @event = new InstructorEquipmentAddedToTemplate(
                EventSourceId,
                quantity,
                equipmentName,
                GetInstructorQuantity(equipmentName) + quantity);
            ApplyEvent(@event);
        }

        public void RemoveInstructorEquipment(int quantity, string equipmentName)
        {
            var @event = new InstructorEquipmentRemovedFromTemplate(
                EventSourceId,
                quantity,
                equipmentName,
                GetInstructorQuantity(equipmentName) - quantity);
            ApplyEvent(@event);
        }

        public void AddStudentEquipment(int quantity, int perStudent, string equipmentName)
        {
            var @event = new StudentEquipmentAddedToTemplate(
                EventSourceId,
                quantity,
                equipmentName,
                perStudent);
            ApplyEvent(@event);
        }

        public void RemoveStudentEquipment(string equipmentName)
        {
            if (!_studentEquipment.ContainsKey(equipmentName))
                throw new StudentEquipmentRequirementDoesntExist();

            var @event = new StudentEquipmentRemovedFromTemplate(
                EventSourceId,
                equipmentName);

            ApplyEvent(@event);
        }
        protected int GetInstructorQuantity(string equipmentName)
        {
            return !_instructorEquipment.ContainsKey(equipmentName) ? 0 : _instructorEquipment[equipmentName];
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

        protected void On(InstructorAssignedToTemplate @event)
        {
            _instructorId = @event.InstructorId;
        }

        protected void On(InstructorUnassignedFromTemplate @event)
        {
            _instructorId = default(Guid);
        }

        protected void On(InstructorEquipmentAddedToTemplate @event)
        {
            _instructorEquipment[@event.EquipmentName] = @event.TotalRequired;
        }

        protected void On(InstructorEquipmentRemovedFromTemplate @event)
        {
            _instructorEquipment[@event.EquipmentName] = @event.TotalRequired;
        }

        protected void On(StudentEquipmentAddedToTemplate @event)
        {
            _studentEquipment[@event.EquipmentName] = new StudentEquipmentQuantity()
                                                          {
                                                              Quantity = @event.Quantity,
                                                              PerStudent = @event.PerStudent
                                                          };
        }

        protected void On(StudentEquipmentRemovedFromTemplate @event)
        {
            _studentEquipment.Remove(@event.EquipmentName);
        }
    }
}
