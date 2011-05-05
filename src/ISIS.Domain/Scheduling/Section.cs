using System;
using System.Linq;
using ISIS.Scheduling.AssignInstructorToSectionExceptions;
using ISIS.Scheduling.CreateSectionExceptions;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{
    public class Section : AggregateRootMappedByConvention 
    {
        private Guid _courseId;
        private string _rubric;
        private string _courseNumber;
        private string _sectionNumber;
        private string _title;
        private string _description;
        private Guid _instructorId;

        private Section()
        {
        }

        public Section(Guid sectionId, TemplateData templateData, Instructor instructor, string sectionNumber)
            : base(sectionId)
        {

            if (instructor != null && instructor.EventSourceId != templateData.InstructorId)
                throw new ApplicationException("The instructor object provided doesn't match the template data.");

            if (templateData.Status != TemplateStatuses.Activated)
                throw new TemplateIsNotActiveException();

            var @event = new SectionCreated(
                EventSourceId,
                templateData.TemplateId,
                templateData.CourseId,
                templateData.TermId,
                templateData.Rubric,
                templateData.CourseNumber,
                sectionNumber,
                templateData.Title,
                templateData.Description);
            ApplyEvent(@event);

            if (instructor != null)
                AssignInstructor(instructor);
        }

        public void AssignInstructor(Instructor instructor)
        {
            if (instructor.EventSourceId == _instructorId) return;

            var instructorData = instructor.GetInstructorData();

            if (!instructorData.AssignedCourses.Contains(_courseId))
                throw new InstructorNotAssignedCourse();

            var @event = new InstructorAssignedToSection(
                EventSourceId,
                _courseId,
                _rubric,
                _courseNumber,
                _sectionNumber,
                _title,
                _description,
                instructorData.InstructorId,
                instructorData.FirstName,
                instructorData.LastName);

            ApplyEvent(@event);
        }

        public void UnassignInstructor()
        {
            if (_instructorId == default(Guid)) return;

            var @event = new InstructorUnassignedFromSection(
                EventSourceId,
                _courseId,
                _rubric,
                _courseNumber,
                _sectionNumber,
                _title,
                _description,
                _instructorId);

            ApplyEvent(@event);
        }

        protected void On(SectionCreated @event)
        {
            _courseId = @event.CourseId;
            _rubric = @event.Rubric;
            _courseNumber = @event.CourseNumber;
            _sectionNumber = @event.SectionNumber;
            _title = @event.Title;
            _description = @event.Description;
        }

        protected void On(InstructorAssignedToSection @event)
        {
            _instructorId = @event.InstructorId;
        }

        protected void On(InstructorUnassignedFromSection @event)
        {
            _instructorId = default(Guid);
        }

    }
}
