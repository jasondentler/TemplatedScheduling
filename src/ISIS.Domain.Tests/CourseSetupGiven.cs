using System;
using ISIS.Commands;
using ISIS.Events;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class CourseSetupGiven
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
        public void GivenIHaveCreatedANewCourse()
        {
            GivenIHaveCreatedANewCourse("BIOL", "1301", "Introductory Biology");
        }

        [Given(@"I have changed the course CIP to (\d{2}\.\d{4})")]
        [Given(@"I have changed the course CIP to (\d{10})")]
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
        public void GivenIHaveChangedTheCourseDescriptionTo(
            string description)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.Given<Course>(new CourseDescriptionChanged(
                                           courseId,
                                           null,
                                           description));
        }






    }
}
