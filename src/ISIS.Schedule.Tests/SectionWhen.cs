using System.Linq;
using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class SectionWhen
    {

        [When(@"I create a section ([^\s]+) from the template")]
        public void WhenICreateASectionFromTheTemplate(
            string sectionNumber)
        {
            var templateId = DomainHelper.Id<Template>();
            var createTemplate = DomainHelper.GetEventStream(templateId).OfType<TemplateCreated>().Single();
            var assignTerm = DomainHelper.GetEventStream(templateId).OfType<TermAssignedToTemplate>().Last();

            var sectionKey = new[]
                                 {
                                     assignTerm.TermName, createTemplate.Rubric, createTemplate.CourseNumber, sectionNumber
                                 };
            var sectionId = DomainHelper.Id<Section>(sectionKey);
            var cmd = new CreateSection(sectionId, templateId, sectionNumber);
            DomainHelper.When(cmd);
        }


    }
}
