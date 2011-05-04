using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
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
