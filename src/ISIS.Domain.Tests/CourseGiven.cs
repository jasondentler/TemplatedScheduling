using ISIS.Events;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class CourseGiven
    {
        [Given(@"I have created a new course ([A-Z]{4}) (\d{4}) ""(.*)""")]
        public void GivenIHaveCreatedANewCourse(
            string rubric,
            string number,
            string title)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.Given<Course>(new CourseCreated(courseId, rubric, number, title));
        }

        [Given(@"I have created a new course")]
        [Given(@"I have created a course")]
        public void GivenIHaveCreatedANewCourse()
        {
            GivenIHaveCreatedANewCourse("BIOL", "1301", "Introductory Biology");
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



        [Given(@"I have activated the course")]
        public void GivenIHaveActivatedTheCourse()
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.Given<Course>(new CourseActivated(courseId));
        }

        [Given(@"I have created and activated a course")]
        public void GivenIHaveCreatedAndActivatedACourse()
        {
            GivenIHaveCreatedANewCourse();
            GivenIHaveChangedTheCourseCIPTo("12.3456");
            GivenIHaveChangedTheCourseDescriptionTo("Description goes here");
            GivenIHaveActivatedTheCourse();
        }


    }
}
