using System.Linq;
using ISIS.Events;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class TemplateThen
    {

        [Then(@"the template is created")]
        public void ThenTheTemplateIsCreated()
        {
            var e = DomainHelper.Then<TemplateCreated>();
            e.Should().Not.Be.Null();
        }

        [Then(@"the template label is ""(.*)""")]
        public void ThenTheTemplateLabelIs(
            string templateLabel)
        {
            var e = DomainHelper.Then<TemplateCreated>();
            e.Label.Should().Be.EqualTo(templateLabel);
        }

        [Then(@"the template is renamed from ""(.*)"" to ""(.*)""")]
        public void ThenTheTemplateIsRenamed(
            string oldLabel, string newLabel)
        {
            var e = DomainHelper.Then<TemplateRenamed>();
            e.OldLabel.Should().Be.EqualTo(oldLabel);
            e.NewLabel.Should().Be.EqualTo(newLabel);
        }


        [Then(@"the template is activated")]
        public void ThenTheCourseIsActivated()
        {
            var e = DomainHelper.Then<TemplateActivated>();
            e.Should().Not.Be.Null();
        }

        [Then(@"the template is made pending")]
        public void ThenTheCourseIsMadePending()
        {
            var e = DomainHelper.Then<TemplateMadePending>();
            e.Should().Not.Be.Null();
        }

        [Then(@"the template is deactivated")]
        public void ThenTheCourseIsDeactivated()
        {
            var e = DomainHelper.Then<TemplateDeactivated>();
            e.Should().Not.Be.Null();
        }

        [Then(@"the template is made obsolete")]
        public void ThenTheCourseIsMadeObsolete()
        {
            var e = DomainHelper.Then<TemplateMadeObsolete>();
            e.Should().Not.Be.Null();
        }

        [Then(@"the template data matches the course data")]
        public void ThenTheTemplateDataMatchesTheCourseData()
        {
            var e = DomainHelper.Then<TemplateCreated>();
            var events = DomainHelper.GetEventStream(e.CourseId);
            var courseCreatedEvent = events.OfType<CourseCreated>().Single();
            var courseRenamedEvent = events.OfType<CourseRenamed>().Last();
            var courseCIPEvent = events.OfType<CourseCIPChanged>().Last();
            var courseDescriptionEvent = events.OfType<CourseDescriptionChanged>().Last();

            e.Rubric.Should().Be.EqualTo(courseCreatedEvent.Rubric);
            e.CourseNumber.Should().Be.EqualTo(courseCreatedEvent.CourseNumber);
            e.Title.Should().Be.EqualTo(courseRenamedEvent.NewTitle);
            e.CIP.Should().Be.EqualTo(courseCIPEvent.NewCIP);
            e.Description.Should().Be.EqualTo(courseDescriptionEvent.NewDescription);
        }

    
    }
}
