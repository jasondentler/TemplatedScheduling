using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class InstructorWhen
    {

        [When(@"I create a new instructor with first name ""([^""]+)"" and last name ""([^""]+)""")]
        public void WhenICreateANewInstructorWith(
            string firstName,
            string lastName)
        {
            var instructorId = DomainHelper.Id<Instructor>(firstName, lastName);
            var cmd = new CreateInstructor(instructorId, firstName, lastName);
            DomainHelper.When(cmd);
        }

        [When(@"I change the instructor's name to ""([^""]+)"" ""([^""]+)""")]
        public void WhenIChangeTheInstructorsName(
            string newFirstName,
            string newLastName)
        {
            var instructorId = DomainHelper.Id<Instructor>();
            var cmd = new ChangeInstructorName(instructorId, newFirstName, newLastName);
            DomainHelper.When(cmd);
        }

        [When(@"I assign the course to the instructor")]
        public void WhenIAssignTheCourseToTheInstructor()
        {
            var instructorId = DomainHelper.Id<Instructor>();
            var courseId = DomainHelper.Id<Course>();

            var cmd = new AssignCourseToInstructor(instructorId, courseId);
            DomainHelper.When(cmd);
        }

        [When(@"I unassign the course from the instructor")]
        public void WhenIUnassignTheCourseFromTheInstructor()
        {
            var instructorId = DomainHelper.Id<Instructor>();
            var courseId = DomainHelper.Id<Course>();

            var cmd = new UnassignCourseFromInstructor(instructorId, courseId);
            DomainHelper.When(cmd);
        }


    }
}
