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

        [When(@"I create a new course ([A-Z]{4}) (\d{4}) ""(.*)""")]
        public void WhenICreateANewCourse(
            string rubric,
            string number,
            string title)
        {
            DomainHelper.Execute(new CreateCourse(Guid.NewGuid(), rubric, number, title));
        }

        [Then(@"the course is created")]
        public void ThenTheCourseIsCreated()
        {
            var e = DomainHelper.Event<CourseCreated>();
            e.Should().Not.Be.Null();
            e.CourseId.Should().Be.EqualTo(DomainHelper.Id<Course>());
        }

    }
}
