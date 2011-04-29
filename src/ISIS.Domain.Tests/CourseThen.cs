﻿using ISIS.Events;
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

        [Then(@"the course is activated")]
        public void ThenTheCourseIsActivated()
        {
            var e = DomainHelper.Then<CourseActivated>();
            e.Should().Not.Be.Null();
        }

        [Then(@"the course is made pending")]
        public void ThenTheCourseIsMadePending()
        {
            var e = DomainHelper.Then<CourseMadePending>();
            e.Should().Not.Be.Null();
        }

        [Then(@"the course is deactivated")]
        public void ThenTheCourseIsDeactivated()
        {
            var e = DomainHelper.Then<CourseDeactivated>();
            e.Should().Not.Be.Null();
        }

        [Then(@"the course is made obsolete")]
        public void ThenTheCourseIsMadeObsolete()
        {
            var e = DomainHelper.Then<CourseMadeObsolete>();
            e.Should().Not.Be.Null();
        }

    }
}