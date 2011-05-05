using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISIS.Scheduling;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class InstructorThen
    {

        [Then(@"the instructor is created")]
        public void ThenTheInstructorIsCreated()
        {
            var e = DomainHelper.Then<InstructorCreated>();
            e.InstructorId.Should().Be.EqualTo(DomainHelper.Id<Instructor>());
        }

        [Then(@"the instructor's first name is ""([^""]+)""")]
        public void ThenTheInstructorsFirstNameIs(
            string firstName)
        {
            var e = DomainHelper.Then<InstructorCreated>();
            e.FirstName.Should().Be.EqualTo(firstName);
        }

        [Then(@"the instructor's last name is ""([^""]+)""")]
        public void ThenTheInstructorsLastNameIs(
            string lastName)
        {
            var e = DomainHelper.Then<InstructorCreated>();
            e.LastName.Should().Be.EqualTo(lastName);
        }

        [Then(@"the instructor's first name is changed from ""([^""]+)"" to ""([^""]+)""")]
        public void ThenTheInstructorsFirstNameIsChanged(
            string oldFirstName, 
            string newFirstName)
        {
            var e = DomainHelper.Then<InstructorNameChanged>();
            e.OldFirstName.Should().Be.EqualTo(oldFirstName);
            e.NewFirstName.Should().Be.EqualTo(newFirstName);
        }

        [Then(@"the instructor's last name is changed from ""([^""]+)"" to ""([^""]+)""")]
        public void ThenTheInstructorsLastNameIsChanged(
            string oldLastName,
            string newLastName)
        {
            var e = DomainHelper.Then<InstructorNameChanged>();
            e.OldLastName.Should().Be.EqualTo(oldLastName);
            e.NewLastName.Should().Be.EqualTo(newLastName);
        }

        [Then(@"the course is assigned to the instructor")]
        public void ThenTheCourseIsAssignedToTheInstructor()
        {
            var instructorId = DomainHelper.Id<Instructor>();
            var courseId = DomainHelper.Id<Course>();
            var instructorCreated = DomainHelper.GetEventStream(instructorId).OfType<InstructorCreated>().Single();
            var courseCreated = DomainHelper.GetEventStream(courseId).OfType<CourseCreated>().Single();

            var e = DomainHelper.Then<InstructorAssignedCourse>();
            e.InstructorId.Should().Be.EqualTo(instructorId);
            e.FirstName.Should().Be.EqualTo(instructorCreated.FirstName);
            e.LastName.Should().Be.EqualTo(instructorCreated.LastName);
            e.CourseId.Should().Be.EqualTo(courseId);
            e.Rubric.Should().Be.EqualTo(courseCreated.Rubric);
            e.CourseNumber.Should().Be.EqualTo(courseCreated.CourseNumber);
        }


        [Then(@"the course is unassigned from the instructor")]
        public void ThenTheCourseIsUnassignedFromTheInstructor()
        {
            var instructorId = DomainHelper.Id<Instructor>();
            var courseId = DomainHelper.Id<Course>();
            var instructorCreated = DomainHelper.GetEventStream(instructorId).OfType<InstructorCreated>().Single();
            var courseCreated = DomainHelper.GetEventStream(courseId).OfType<CourseCreated>().Single();

            var e = DomainHelper.Then<InstructorUnassignedCourse>();
            e.InstructorId.Should().Be.EqualTo(instructorId);
            e.FirstName.Should().Be.EqualTo(instructorCreated.FirstName);
            e.LastName.Should().Be.EqualTo(instructorCreated.LastName);
            e.CourseId.Should().Be.EqualTo(courseId);
            e.Rubric.Should().Be.EqualTo(courseCreated.Rubric);
            e.CourseNumber.Should().Be.EqualTo(courseCreated.CourseNumber);
        }


    }
}
