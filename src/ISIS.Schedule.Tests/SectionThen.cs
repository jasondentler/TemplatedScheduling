using System.Linq;
using ISIS.Scheduling;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class SectionThen
    {

        [Then(@"section ([^\s]+) is created")]
        public void ThenSectionIsCreated(
            string sectionNumber)
        {
            var e = DomainHelper.Then<SectionCreated>();
            e.SectionId.Should().Be.EqualTo(DomainHelper.Id<Section>());
            e.SectionNumber.Should().Be.EqualTo(sectionNumber);
        }


        [Then(@"the section data matches the basic template data")]
        public void ThenTheSectionDataMatchesTheTemplateData()
        {
            var e = DomainHelper.Then<SectionCreated>();
            var templateEvents = DomainHelper.GetEventStream(DomainHelper.Id<Template>());
            var templateCreated = templateEvents.OfType<TemplateCreated>().Single();
            var termAssigned = templateEvents.OfType<TermAssignedToTemplate>().Last();

            e.TemplateId.Should().Be.EqualTo(templateCreated.TemplateId);
            e.CourseId.Should().Be.EqualTo(templateCreated.CourseId);
            e.Rubric.Should().Be.EqualTo(templateCreated.Rubric);
            e.CourseNumber.Should().Be.EqualTo(templateCreated.CourseNumber);
            e.Title.Should().Be.EqualTo(templateCreated.Title);
            e.Description.Should().Be.EqualTo(templateCreated.Description);

            e.TermId.Should().Be.EqualTo(termAssigned.TermId);
        }

    }
}
