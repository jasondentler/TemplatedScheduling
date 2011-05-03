using ISIS.Commands;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class CourseWhen
    {

        [When(@"I create a new course ([A-Z]{4}) (\d{4})")]
        public void WhenICreateANewCourse(
            string rubric,
            string number)
        {
            var courseId = DomainHelper.Id<Course>(rubric, number);
            DomainHelper.When(new CreateCourse(courseId, rubric, number));
        }

        [When(@"I rename the course to ""([^""]*)""")]
        public void WhenIChangeTheCourseTitleTo(
            string newTitle)
        {
            WhenIRenameTheCourseTo(newTitle, newTitle);
        }

        [When(@"I rename the course to ""([^""]*)"" with short title ""([^""]*)""")]
        public void WhenIRenameTheCourseTo(
            string newTitle,
            string newShortTitle)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.When(new RenameCourse(courseId, newTitle, newShortTitle));
        }


        [When(@"I change the course CIP to (\d{2}\.\d{4})")]
        [When(@"I change the course CIP to (\d{10})")]
        public void WhenIChangeTheCourseCIPTo(
            string cip)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.When(new ChangeCourseCIP(courseId, cip));
        }

        [When(@"I change the course description to ""(.*)""")]
        public void WhenIChangeTheCourseDescriptionTo(
            string newDescription)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.When(new ChangeCourseDescription(
                courseId,
                newDescription));
        }


    }
}
