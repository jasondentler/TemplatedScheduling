using System;
using System.Collections.Generic;
using System.Linq;
using ISIS.Scheduling;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
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
            var courseDescriptionEvent = events.OfType<CourseDescriptionChanged>().Last();

            e.Rubric.Should().Be.EqualTo(courseCreatedEvent.Rubric);
            e.CourseNumber.Should().Be.EqualTo(courseCreatedEvent.CourseNumber);
            e.Title.Should().Be.EqualTo(courseRenamedEvent.NewTitle);
            e.Description.Should().Be.EqualTo(courseDescriptionEvent.NewDescription);
        }

        [Then(@"the term is assigned to the template")]
        public void ThenTheTermIsAssignedToTheTemplate()
        {
            var templateId = DomainHelper.Id<Template>();
            var termId = DomainHelper.Id<Term>();
            var termCreated = DomainHelper.GetEventStream(termId).OfType<TermCreated>().Single();

            var e = DomainHelper.Then<TermAssignedToTemplate>();
            e.TemplateId.Should().Be.EqualTo(templateId);
            e.TermId.Should().Be.EqualTo(termId);
            e.TermName.Should().Be.EqualTo(termCreated.Name);
        }

        [Then(@"the template's start and end dates are blank")]
        public void ThenTheTemplateSStartAndEndDatesAreBlank()
        {
            var e = DomainHelper.Then<TermAssignedToTemplate>();
            e.StartDate.Should().Be.EqualTo(null);
            e.EndDate.Should().Be.EqualTo(null);
        }

        [Then(@"the template's start and end dates match the term")]
        public void ThenTheTemplateSStartAndEndDatesMatchTheTerm()
        {
            var termId = DomainHelper.Id<Term>();
            var termCreated = DomainHelper.GetEventStream(termId).OfType<TermCreated>().Single();

            var e = DomainHelper.Then<TermAssignedToTemplate>();
            e.StartDate.Should().Be.EqualTo(termCreated.StartDate);
            e.EndDate.Should().Be.EqualTo(termCreated.EndDate);
        }

        [Then(@"the template ""(.*)"" is copied to ""(.*)""")]
        public void ThenTheTemplateIsCopied(
            string sourceTemplateLabel,
            string newTemplateLabel)
        {
            var sourceTemplateId = DomainHelper.Id<Template>(sourceTemplateLabel);
            var newTemplateId = DomainHelper.Id<Template>(newTemplateLabel);
            var sourceEvents = DomainHelper.GetEventStream(sourceTemplateId);
            var sourceCreated = sourceEvents.OfType<TemplateCreated>().Single();
            var sourceTermAssigned = sourceEvents.OfType<TermAssignedToTemplate>().LastOrDefault();
            var sourceStatus = GetStatus(sourceEvents);

            var data = new TemplateData()
                                 {
                                     CourseId = sourceCreated.CourseId,
                                     CourseNumber = sourceCreated.CourseNumber,
                                     Description = sourceCreated.Description,
                                     IsContinuingEducation = sourceCreated.IsContinuingEducation,
                                     Label = sourceCreated.Label,
                                     Rubric = sourceCreated.Rubric,
                                     Status = sourceStatus,
                                     TemplateId = sourceTemplateId,
                                     TermId = sourceTermAssigned == null ? default(Guid) : sourceTermAssigned.TermId,
                                     Title = sourceCreated.Title
                                 };

            var e = DomainHelper.Then<TemplateCopied>();
            e.CourseId.Should().Be.EqualTo(data.CourseId);
            e.CourseNumber.Should().Be.EqualTo(data.CourseNumber);
            e.Description.Should().Be.EqualTo(data.Description);
            e.IsContinuingEducation.Should().Be.Equals(data.IsContinuingEducation);
            e.NewLabel.Should().Be.EqualTo(newTemplateLabel);
            e.NewTemplateId.Should().Be.EqualTo(newTemplateId);
            e.Rubric.Should().Be.EqualTo(data.Rubric);
            e.SourceLabel.Should().Be.EqualTo(sourceTemplateLabel);
            e.SourceTemplateId.Should().Be.EqualTo(sourceTemplateId);
            e.Status.Should().Be.EqualTo(sourceStatus);
            e.TermId.Should().Be.EqualTo(data.TermId);
            e.Title.Should().Be.EqualTo(data.Title);

        }

        private static TemplateStatuses GetStatus(IEnumerable<object> eventStream)
        {
            return GetStatus(
                eventStream.Where(
                    e =>
                    e is ActivateTemplate || e is DeactivateTemplate || e is MakeTemplatePending ||
                    e is MakeTemplateObsolete || e is TemplateCopied).LastOrDefault());
        }

        private static TemplateStatuses GetStatus(object statusEvent)
        {
            if (statusEvent == null)
                return TemplateStatuses.Pending;
            if (statusEvent is ActivateTemplate)
                return TemplateStatuses.Activated;
            if (statusEvent is DeactivateTemplate)
                return TemplateStatuses.Deactivated;
            if (statusEvent is MakeTemplatePending)
                return TemplateStatuses.Pending;
            if (statusEvent is MakeTemplateObsolete)
                return TemplateStatuses.Obsolete;
            throw new NotSupportedException();
        }


    }
}
