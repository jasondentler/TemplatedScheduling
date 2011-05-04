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
            var templateEvent = templateEvents.OfType<TemplateCreated>().Single();

            e.TemplateId.Should().Be.EqualTo(templateEvent.TemplateId);
            e.CourseId.Should().Be.EqualTo(templateEvent.CourseId);
            e.Rubric.Should().Be.EqualTo(templateEvent.Rubric);
            e.CourseNumber.Should().Be.EqualTo(templateEvent.CourseNumber);
            e.Title.Should().Be.EqualTo(templateEvent.Title);
            e.Description.Should().Be.EqualTo(templateEvent.Description);
        }

    }
}
