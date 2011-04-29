using System;
using ISIS.Commands;
using ISIS.Events;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class CourseSetupSteps
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

        [When(@"I create a new course ([A-Z]{4}) (\d{4}) ""(.*)""")]
        public void WhenICreateANewCourse(
            string rubric,
            string number,
            string title)
        {
            DomainHelper.When(new CreateCourse(Guid.NewGuid(), rubric, number, title));
        }

        [When(@"I change the course title to ""(.*)""")]
        public void WhenIChangeTheCourseTitleTo(
            string newTitle)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.When(new ChangeCourseTitle(courseId, newTitle));
        }


        [Then(@"the course is created")]
        public void ThenTheCourseIsCreated()
        {
            var e = DomainHelper.Then<CourseCreated>();
            e.CourseId.Should().Be.EqualTo(DomainHelper.Id<Course>());
        }

        [Then(@"the course title is changed from ""(.*)"" to ""(.*)""")]
        public void ThenTheCourseTitleIsChanged(
            string oldTitle,
            string newTitle)
        {
            var e = DomainHelper.Then<CourseTitleChanged>();
            e.OldTitle.Should().Be.EqualTo(oldTitle);
            e.NewTitle.Should().Be.EqualTo(newTitle);
        }



    }
}
