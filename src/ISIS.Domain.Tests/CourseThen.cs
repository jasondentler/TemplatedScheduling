using ISIS.Events;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class CourseThen
    {
        [Then(@"the course is created")]
        public void ThenTheCourseIsCreated()
        {
            var e = DomainHelper.Then<CourseCreated>();
            e.CourseId.Should().Be.EqualTo(DomainHelper.Id<Course>());
            e.IsContinuingEducation.Should().Be.False();
        }

        [Then(@"the CE course is created")]
        public void ThenTheCECourseIsCreated()
        {
            var e = DomainHelper.Then<CourseCreated>();
            e.CourseId.Should().Be.EqualTo(DomainHelper.Id<Course>());
            e.IsContinuingEducation.Should().Be.True();
        }


        [Then(@"the course is renamed to ""([^""]*)""")]
        public void ThenTheCourseIsRenamedTo(
            string newTitle)
        {
            ThenTheCourseIsRenamedTo(newTitle, newTitle);
        }

        [Then(@"the course is renamed to ""([^""]*)"" with short title ""([^""]*)""")]
        public void ThenTheCourseIsRenamedTo(
            string newTitle,
            string newShortTitle)
        {
            ThenTheCourseIsRenamed(null, null, newTitle, newShortTitle);
        }
        
        [Then(@"the course is renamed from ""([^""]*)"" to ""([^""]*)""")]
        public void ThenTheCourseIsRenamedFromTo(
            string oldTitle,
            string newTitle)
        {
            ThenTheCourseIsRenamed(oldTitle, oldTitle, newTitle, newTitle);
        }

        [Then(@"the course is renamed from ""([^""]*)"" with short title ""([^""]*)"" to ""([^""]*)"" with short title ""([^""]*)""")]
        public void ThenTheCourseIsRenamed(
            string oldTitle,
            string oldShortTitle,
            string newTitle,
            string newShortTitle)
        {
            var e = DomainHelper.Then<CourseRenamed>();
            e.OldTitle.Should().Be.EqualTo(oldTitle);
            e.OldShortTitle.Should().Be.EqualTo(oldShortTitle);
            e.NewTitle.Should().Be.EqualTo(newTitle);
            e.NewShortTitle.Should().Be.EqualTo(newShortTitle);
        }


        [Then(@"the course CIP is set to (\d{2}\.\d{4})")]
        [Then(@"the course CIP is set to (\d{10})")]
        public void ThenTheCourseCIPIsSetTo(
            string cip)
        {
            var e = DomainHelper.Then<CourseCIPChanged>();
            e.OldCIP.Should().Be.NullOrEmpty();
            e.NewCIP.Should().Be.EqualTo(cip);
        }

        [Then(@"the course description is changed from ""(.*)"" to ""(.*)""")]
        public void ThenTheCourseDescriptionIsChanged(
            string oldDescription,
            string newDescription)
        {
            var e = DomainHelper.Then<CourseDescriptionChanged>();
            e.OldDescription.Should().Be.EqualTo(oldDescription);
            e.NewDescription.Should().Be.EqualTo(newDescription);
        }

        [Then(@"the course description is set to ""(.*)""")]
        public void ThenTheCourseDescriptionIsSetTo(
            string newDescription)
        {
            var e = DomainHelper.Then<CourseDescriptionChanged>();
            e.OldDescription.Should().Be.NullOrEmpty();
            e.NewDescription.Should().Be.EqualTo(newDescription);
        }


    }
}
