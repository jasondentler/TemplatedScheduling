using System;
using System.Collections.Generic;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{
    public class Course : AggregateRootMappedByConvention
    {

        private string _rubric;
        private string _courseNumber;
        private string _title;
        private string _shortTitle;
        private string _description;
        private bool _isContinuingEducation;
        private readonly Dictionary<string, int> _instructorEquipment = new Dictionary<string, int>();

        private readonly Dictionary<string, StudentEquipmentQuantity> _studentEquipment =
            new Dictionary<string, StudentEquipmentQuantity>();

        private Course()
        {
        }
        
        public Course(Guid courseId, string rubric, string courseNumber)
            : base(courseId)
        {
            ApplyEvent(new CourseCreated(EventSourceId, rubric, courseNumber, IsContinuingEducation(courseNumber)));
        }

        public void ChangeTitle(string newTitle, string newShortTitle)
        {
            if (_title != newTitle || _shortTitle != newShortTitle)
                ApplyEvent(new CourseRenamed(
                               EventSourceId,
                               _title,
                               newTitle,
                               _shortTitle,
                               newShortTitle));
        }
        
        public void ChangeDescription(string description)
        {
            if (_description != description)
                ApplyEvent(new CourseDescriptionChanged(
                               EventSourceId,
                               _description,
                               description));
        }

        public void AddInstructorEquipment(int quantity, string equipmentName)
        {
            var @event = new InstructorEquipmentAddedToCourse(
                EventSourceId,
                quantity,
                equipmentName,
                GetInstructorQuantity(equipmentName) + quantity);
            ApplyEvent(@event);
        }

        public void RemoveInstructorEquipment(int quantity, string equipmentName)
        {
            var @event = new InstructorEquipmentRemovedFromCourse(
                EventSourceId,
                quantity,
                equipmentName,
                GetInstructorQuantity(equipmentName) - quantity);
            ApplyEvent(@event);
        }

        public void AddStudentEquipment(int quantity, int perStudent, string equipmentName)
        {
            var @event = new StudentEquipmentAddedToCourse(
                EventSourceId,
                quantity,
                equipmentName,
                perStudent);
            ApplyEvent(@event);
        }

        public void RemoveStudentEquipment(string equipmentName)
        {
            var @event = new StudentEquipmentRemovedFromCourse(
                EventSourceId,
                equipmentName);

            ApplyEvent(@event);
        }
        
        internal CourseData GetCourseData()
        {
            return new CourseData()
                       {
                           CourseId = EventSourceId,
                           Rubric = _rubric,
                           CourseNumber = _courseNumber,
                           Title = _title,
                           Description = _description,
                           IsContinuingEducation = _isContinuingEducation,
                           InstructorEquipment = new Dictionary<string, int>(_instructorEquipment),
                           StudentEquipment = new Dictionary<string, StudentEquipmentQuantity>(_studentEquipment)
                       };
        }

        protected int GetInstructorQuantity(string equipmentName)
        {
            return !_instructorEquipment.ContainsKey(equipmentName) ? 0 : _instructorEquipment[equipmentName];
        }

        protected void On(CourseCreated @event)
        {
            _rubric = @event.Rubric;
            _courseNumber = @event.CourseNumber;
            _isContinuingEducation = @event.IsContinuingEducation;
        }

        protected void On(CourseRenamed @event)
        {
            _title = @event.NewTitle;
            _shortTitle = @event.NewShortTitle;
        }
        
        protected void On(CourseDescriptionChanged @event)
        {
            _description = @event.NewDescription;
        }

        private static int GetCreditHours(string courseNumber)
        {
            return int.Parse(courseNumber.Substring(1, 1));
        }

        private static bool IsContinuingEducation(string courseNumber)
        {
            return GetCreditHours(courseNumber) == 0;
        }

        protected void On(InstructorEquipmentAddedToCourse @event)
        {
            _instructorEquipment[@event.EquipmentName] = @event.TotalRequired;
        }

        protected void On(InstructorEquipmentRemovedFromCourse @event)
        {
            _instructorEquipment[@event.EquipmentName] = @event.TotalRequired;
        }

        protected void On(StudentEquipmentAddedToCourse @event)
        {
            _studentEquipment[@event.EquipmentName] =
                new StudentEquipmentQuantity()
                    {
                        Quantity = @event.Quantity,
                        PerStudent = @event.PerStudent
                    };
        }

        protected void On(StudentEquipmentRemovedFromCourse @event)
        {
            _studentEquipment.Remove(@event.EquipmentName);
        }

    }
}
