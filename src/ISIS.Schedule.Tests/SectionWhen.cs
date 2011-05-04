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
            var sectionId = DomainHelper.Id<Section>();
            var cmd = new CreateSection(sectionId, templateId, sectionNumber);
            DomainHelper.When(cmd);
        }


    }
}
