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
    public class FacultyThen
    {

        [Then(@"the faculty member is created")]
        public void ThenTheFacultyMemberIsCreated()
        {
            var e = DomainHelper.Then<FacultyCreated>();
            e.FacultyId.Should().Be.EqualTo(DomainHelper.Id<Faculty>());
        }

        [Then(@"the faculty member's first name is ""([^""]+)""")]
        public void ThenTheFacultyMemberSFirstNameIs(
            string firstName)
        {
            var e = DomainHelper.Then<FacultyCreated>();
            e.FirstName.Should().Be.EqualTo(firstName);
        }

        [Then(@"the faculty member's last name is ""([^""]+)""")]
        public void ThenTheFacultyMemberSLastNameIs(
            string lastName)
        {
            var e = DomainHelper.Then<FacultyCreated>();
            e.LastName.Should().Be.EqualTo(lastName);
        }

        [Then(@"the faculty first name is changed from ""([^""]+)"" to ""([^""]+)""")]
        public void ThenTheFacultyFirstNameIsChanged(
            string oldFirstName, 
            string newFirstName)
        {
            var e = DomainHelper.Then<FacultyNameChanged>();
            e.OldFirstName.Should().Be.EqualTo(oldFirstName);
            e.NewFirstName.Should().Be.EqualTo(newFirstName);
        }

        [Then(@"the faculty last name is changed from ""([^""]+)"" to ""([^""]+)""")]
        public void ThenTheFacultyLastNameIsChanged(
            string oldLastName,
            string newLastName)
        {
            var e = DomainHelper.Then<FacultyNameChanged>();
            e.OldLastName.Should().Be.EqualTo(oldLastName);
            e.NewLastName.Should().Be.EqualTo(newLastName);
        }

        [Then(@"the course is assigned to the faculty member")]
        public void ThenTheCourseIsAssignedToTheFacultyMember()
        {
            var facultyId = DomainHelper.Id<Faculty>();
            var courseId = DomainHelper.Id<Course>();
            var facultyCreated = DomainHelper.GetEventStream(facultyId).OfType<FacultyCreated>().Single();
            var courseCreated = DomainHelper.GetEventStream(courseId).OfType<CourseCreated>().Single();

            var e = DomainHelper.Then<FacultyAssignedCourse>();
            e.FacultyId.Should().Be.EqualTo(facultyId);
            e.FirstName.Should().Be.EqualTo(facultyCreated.FirstName);
            e.LastName.Should().Be.EqualTo(facultyCreated.LastName);
            e.CourseId.Should().Be.EqualTo(courseId);
            e.Rubric.Should().Be.EqualTo(courseCreated.Rubric);
            e.CourseNumber.Should().Be.EqualTo(courseCreated.CourseNumber);
        }


        [Then(@"the course is unassigned from the faculty member")]
        public void ThenTheCourseIsUnassignedFromTheFacultyMember()
        {
            var facultyId = DomainHelper.Id<Faculty>();
            var courseId = DomainHelper.Id<Course>();
            var facultyCreated = DomainHelper.GetEventStream(facultyId).OfType<FacultyCreated>().Single();
            var courseCreated = DomainHelper.GetEventStream(courseId).OfType<CourseCreated>().Single();

            var e = DomainHelper.Then<FacultyUnassignedCourse>();
            e.FacultyId.Should().Be.EqualTo(facultyId);
            e.FirstName.Should().Be.EqualTo(facultyCreated.FirstName);
            e.LastName.Should().Be.EqualTo(facultyCreated.LastName);
            e.CourseId.Should().Be.EqualTo(courseId);
            e.Rubric.Should().Be.EqualTo(courseCreated.Rubric);
            e.CourseNumber.Should().Be.EqualTo(courseCreated.CourseNumber);
        }


    }
}
