using System;
using ISIS.Commands;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class CourseWhen
    {

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

        [When(@"I activate the course")]
        public void WhenIActivateTheCourse()
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.When(new ActivateCourse(courseId));
        }

        [When(@"I make the course pending")]
        public void WhenIMakeTheCoursePending()
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.When(new MakeCoursePending(courseId));
        }

        [When(@"I deactivate the course")]
        public void WhenIDeactivateTheCourse()
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.When(new DeactivateCourse(courseId));
        }

        [When(@"I make the course obsolete")]
        public void WhenIMakeTheCourseObsolete()
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.When(new MakeCourseObsolete(courseId));
        }


    }
}
