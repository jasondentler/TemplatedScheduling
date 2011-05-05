using System;
using System.Collections.Generic;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{
    public class Faculty : AggregateRootMappedByConvention 
    {
        private string _firstName;
        private string _lastName;
        private HashSet<Guid> _courses = new HashSet<Guid>();

        private Faculty()
        {
        }

        public Faculty(Guid facultyId, string firstName, string lastName)
            : base(facultyId)
        {
            ApplyEvent(new FacultyCreated(EventSourceId, firstName, lastName));
        }

        public void ChangeName(string newFirstName, string newLastName)
        {
            if (_firstName != newFirstName || _lastName != newLastName)
                ApplyEvent(new FacultyNameChanged(
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
            var @event = new FacultyAssignedCourse(
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
            var @event = new FacultyUnassignedCourse(
                EventSourceId,
                _firstName,
                _lastName,
                courseData.CourseId,
                courseData.Rubric,
                courseData.CourseNumber);
            ApplyEvent(@event);
        }

        protected void On(FacultyCreated @event)
        {
            _firstName = @event.FirstName;
            _lastName = @event.LastName;
        }

        protected void On(FacultyNameChanged @event)
        {
            _firstName = @event.NewFirstName;
            _lastName = @event.NewLastName;
        }

        protected void On(FacultyAssignedCourse @event)
        {
            _courses.Add(@event.CourseId);
        }

        protected void On(FacultyUnassignedCourse @event)
        {
            _courses.Remove(@event.CourseId);
        }

    }
}
