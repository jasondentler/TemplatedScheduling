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

        [Then(@"the instructor is assigned to the section")]
        public void ThenTheInstructorIsAssignedToTheSection()
        {
            var instructorId = DomainHelper.Id<Instructor>();
            var sectionId = DomainHelper.Id<Section>();
            var sectionCreated = DomainHelper.GetEventStream(sectionId).OfType<SectionCreated>().Single();
            var instructorCreated = DomainHelper.GetEventStream(instructorId).OfType<InstructorCreated>().Single();

            var e = DomainHelper.Then<InstructorAssignedToSection>();
            e.SectionId.Should().Be.EqualTo(sectionId);
            e.CourseId.Should().Be.EqualTo(sectionCreated.CourseId);
            e.Rubric.Should().Be.EqualTo(sectionCreated.Rubric);
            e.CourseNumber.Should().Be.EqualTo(sectionCreated.CourseNumber);
            e.SectionNumber.Should().Be.EqualTo(sectionCreated.SectionNumber);
            e.Title.Should().Be.EqualTo(sectionCreated.Title);
            e.Description.Should().Be.EqualTo(sectionCreated.Description);
            e.InstructorId.Should().Be.EqualTo(instructorId);
            e.FirstName.Should().Be.EqualTo(instructorCreated.FirstName);
            e.LastName.Should().Be.EqualTo(instructorCreated.LastName);
        }

        [Then(@"the instructor is unassigned from the section")]
        public void ThenTheInstructorIsUnassignedFromTheSection()
        {
            var instructorId = DomainHelper.Id<Instructor>();
            var sectionId = DomainHelper.Id<Section>();
            var sectionCreated = DomainHelper.GetEventStream(sectionId).OfType<SectionCreated>().Single();

            var e = DomainHelper.Then<InstructorUnassignedFromSection>();
            e.SectionId.Should().Be.EqualTo(sectionId);
            e.CourseId.Should().Be.EqualTo(sectionCreated.CourseId);
            e.Rubric.Should().Be.EqualTo(sectionCreated.Rubric);
            e.CourseNumber.Should().Be.EqualTo(sectionCreated.CourseNumber);
            e.SectionNumber.Should().Be.EqualTo(sectionCreated.SectionNumber);
            e.Title.Should().Be.EqualTo(sectionCreated.Title);
            e.Description.Should().Be.EqualTo(sectionCreated.Description);
            e.InstructorId.Should().Be.EqualTo(instructorId);
        }

    }
}
