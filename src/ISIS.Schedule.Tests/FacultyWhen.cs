using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class FacultyWhen
    {

        [When(@"I create a new faculty member with first name ""([^""]+)"" and last name ""([^""]+)""")]
        public void WhenICreateANewFacultyMemberWith(
            string firstName,
            string lastName)
        {
            var facultyId = DomainHelper.Id<Faculty>(firstName, lastName);
            var cmd = new CreateFaculty(facultyId, firstName, lastName);
            DomainHelper.When(cmd);
        }

        [When(@"I change the faculty name to ""([^""]+)"" ""([^""]+)""")]
        public void WhenIChangeTheFacultyName(
            string newFirstName,
            string newLastName)
        {
            var facultyId = DomainHelper.Id<Faculty>();
            var cmd = new ChangeFacultyName(facultyId, newFirstName, newLastName);
            DomainHelper.When(cmd);
        }

        [When(@"I assign the course to the faculty member")]
        public void WhenIAssignTheCourseToTheFacultyMember()
        {
            var facultyId = DomainHelper.Id<Faculty>();
            var courseId = DomainHelper.Id<Course>();

            var cmd = new AssignCourseToFaculty(facultyId, courseId);
            DomainHelper.When(cmd);
        }

        [When(@"I unassign the course from the faculty member")]
        public void WhenIUnassignTheCourseFromTheFacultyMember()
        {
            var facultyId = DomainHelper.Id<Faculty>();
            var courseId = DomainHelper.Id<Course>();

            var cmd = new UnassignCourseFromFaculty(facultyId, courseId);
            DomainHelper.When(cmd);
        }


    }
}
