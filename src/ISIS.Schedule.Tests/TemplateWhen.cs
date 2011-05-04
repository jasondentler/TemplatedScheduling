using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class TemplateWhen
    {

        [When(@"I create the template ""(.*)""")]
        public void WhenICreateTheTemplate(
            string templateLabel)
        {
            var courseId = DomainHelper.Id<Course>();
            var templateId = DomainHelper.Id<Template>(templateLabel);

            var cmd = new CreateTemplate(templateId, templateLabel, courseId);
            DomainHelper.When(cmd);
        }

        [When(@"I create the template")]
        public void WhenICreateTheTemplate()
        {
            WhenICreateTheTemplate("Template Label");
        }

        [When(@"I rename the template to ""(.*)""")]
        public void WhenIChangeTheTemplateLabelToTemplateLabelHere(
            string templateLabel)
        {
            var templateId = DomainHelper.Id<Template>();
            var cmd = new RenameTemplate(templateId, templateLabel);
            DomainHelper.When(cmd);
        }

        [When(@"I activate the template")]
        public void WhenIActivateTheTemplate()
        {
            var templateId = DomainHelper.Id<Template>();
            var cmd = new ActivateTemplate(templateId);
            DomainHelper.When(cmd);
        }

        [When(@"I make the template pending")]
        public void WhenIMakeTheTemplatePending()
        {
            var templateId = DomainHelper.Id<Template>();
            var cmd = new MakeTemplatePending(templateId);
            DomainHelper.When(cmd);
        }

        [When(@"I deactivate the template")]
        public void WhenIDeactivateTheTemplate()
        {
            var templateId = DomainHelper.Id<Template>();
            var cmd = new DeactivateTemplate(templateId);
            DomainHelper.When(cmd);
        }

        [When(@"I make the template obsolete")]
        public void WhenIMakeTheTemplateObsolete()
        {
            var templateId = DomainHelper.Id<Template>();
            var cmd = new MakeTemplateObsolete(templateId);
            DomainHelper.When(cmd);
        }

        [When(@"I assign the term to the template")]
        public void WhenIAssignTheTermToTheTemplate()
        {
            var templateId = DomainHelper.Id<Template>();
            var termId = DomainHelper.Id<Term>();
            var cmd = new AssignTermToTemplate(templateId, termId);
            DomainHelper.When(cmd);
        }


    }
}
