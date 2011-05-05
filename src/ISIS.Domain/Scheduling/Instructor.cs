using System;
using System.Collections.Generic;
using System.Linq;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{
    public class Instructor : AggregateRootMappedByConvention 
    {
        private string _firstName;
        private string _lastName;
        private HashSet<Guid> _courses = new HashSet<Guid>();

        private Instructor()
        {
        }

        public Instructor(Guid instructorId, string firstName, string lastName)
            : base(instructorId)
        {
            ApplyEvent(new InstructorCreated(EventSourceId, firstName, lastName));
        }

        public void ChangeName(string newFirstName, string newLastName)
        {
            if (_firstName != newFirstName || _lastName != newLastName)
                ApplyEvent(new InstructorNameChanged(
                               EventSourceId,
                               _firstName,
                               _lastName,
                               newFirstName,
                               newLastName));
        }

        public void AssignCourse(Course course)
        {
            if (_courses.Contains(course.EventSourceId)) return;

            var courseData = course.GetCourseData();
            var @event = new InstructorAssignedCourse(
                EventSourceId,
                _firstName,
                _lastName,
                courseData.CourseId,
                courseData.Rubric,
                courseData.CourseNumber);
            ApplyEvent(@event);
        }


        public void UnassignCourse(Course course)
        {
            if (!_courses.Contains(course.EventSourceId)) return;

            var courseData = course.GetCourseData();
            var @event = new InstructorUnassignedCourse(
                EventSourceId,
                _firstName,
                _lastName,
                courseData.CourseId,
                courseData.Rubric,
                courseData.CourseNumber);
            ApplyEvent(@event);
        }

        internal InstructorData GetInstructorData()
        {
            return new InstructorData()
                       {
                           InstructorId = EventSourceId,
                           FirstName = _firstName,
                           LastName = _lastName,
                           AssignedCourses = _courses.ToArray()
                       };
        }


        protected void On(InstructorCreated @event)
        {
            _firstName = @event.FirstName;
            _lastName = @event.LastName;
        }

        protected void On(InstructorNameChanged @event)
        {
            _firstName = @event.NewFirstName;
            _lastName = @event.NewLastName;
        }

        protected void On(InstructorAssignedCourse @event)
        {
            _courses.Add(@event.CourseId);
        }

        protected void On(InstructorUnassignedCourse @event)
        {
            _courses.Remove(@event.CourseId);
        }

    }
}
