using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class FacultyGiven
    {

        [Given(@"I create a new faculty member with first name ""([^""]+)"" and last name ""([^""]+)""")]
        public void GivenICreateANewFacultyMember(
            string firstName,
            string lastName)
        {
            var facultyId = DomainHelper.Id<Faculty>(firstName, lastName);
            var @event = new FacultyCreated(facultyId, firstName, lastName);
            DomainHelper.Given<Faculty>(facultyId, @event);
        }

        [Given(@"I have created a new faculty member")]
        public void GivenIHaveCreatedANewFacultyMember()
        {
            GivenICreateANewFacultyMember("John", "Smith");
        }


        [Given(@"I have assigned the course to the faculty member")]
        public void GivenIHaveAssignedTheCourseToTheFacultyMember()
        {
            var facultyId = DomainHelper.Id<Faculty>();
            var courseId = DomainHelper.Id<Course>();
            var facultyCreated = DomainHelper.GetEventStream(facultyId).OfType<FacultyCreated>().Single();
            var courseCreated = DomainHelper.GetEventStream(courseId).OfType<CourseCreated>().Single();

            var @event = new FacultyAssignedCourse(
                facultyId, facultyCreated.FirstName, facultyCreated.LastName,
                courseId, courseCreated.Rubric, courseCreated.CourseNumber);
            DomainHelper.Given<Faculty>(@event);
        }


    }
}
