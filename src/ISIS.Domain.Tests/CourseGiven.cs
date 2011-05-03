using System.Linq;
using ISIS.Events;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class CourseGiven
    {
        [Given(@"I have created a new course ([A-Z]{4}) (\d{4})")]
        public void GivenIHaveCreatedANewCourse(
            string rubric,
            string number)
        {
            var courseId = DomainHelper.Id<Course>(rubric, number);
            DomainHelper.Given<Course>(new CourseCreated(courseId, rubric, number));
        }

        [Given(@"I have created a new course")]
        [Given(@"I have created a course")]
        public void GivenIHaveCreatedANewCourse()
        {
            GivenIHaveCreatedANewCourse("BIOL", "1301");
        }

        [Given(@"I have renamed the course to ""([^""]*)""")]
        public void GivenIHaveRenamedTheCourseTo(
            string newTitle)
        {
            GivenIHaveRenamedTheCourseTo(newTitle, newTitle);
        }

        [Given(@"I have renamed the course to ""([^""]*)"" with short title ""([^""]*)""")]
        public void GivenIHaveRenamedTheCourseTo(
            string newTitle,
            string newShortTitle)
        {
            var courseId = DomainHelper.Id<Course>();
            var renameEvents = DomainHelper.GetEventStream(courseId)
                .OfType<CourseRenamed>();

            var oldTitle = renameEvents.Select(e => e.NewTitle).LastOrDefault();
            var oldShortTitle = renameEvents.Select(e => e.NewShortTitle).LastOrDefault();
            DomainHelper.Given<Course>(new CourseRenamed(courseId,
                                                         oldTitle, newTitle,
                                                         oldShortTitle, newShortTitle));
        }


        [Given(@"I have changed the course CIP to (\d{2}\.\d{4})")]
        [Given(@"I have changed the course CIP to (\d{10})")]
        [Given(@"I have set the course CIP to (\d{2}\.\d{4})")]
        [Given(@"I have set the course CIP to (\d{10})")]
        public void GivenIHaveChangedTheCourseCIPTo(
            string cip)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.Given<Course>(new CourseCIPChanged(
                                           courseId,
                                           null,
                                           cip));
        }

        [Given(@"I have changed the course description to ""(.*)""")]
        [Given(@"I have set the course description to ""(.*)""")]
        public void GivenIHaveChangedTheCourseDescriptionTo(
            string description)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.Given<Course>(new CourseDescriptionChanged(
                                           courseId,
                                           null,
                                           description));
        }


        [Given(@"I have set up a new course")]
        public void GivenIHaveSetUpANewCourse()
        {
            GivenIHaveCreatedANewCourse("BIOL", "1301");
            GivenIHaveRenamedTheCourseTo("Introductory Biology");
            GivenIHaveChangedTheCourseCIPTo("12.3456");
            GivenIHaveChangedTheCourseDescriptionTo("Cuttin' up frogs");
        }


    }
}
