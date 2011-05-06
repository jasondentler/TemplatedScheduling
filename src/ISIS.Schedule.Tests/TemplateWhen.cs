using System.Linq;
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

        [When(@"I copy the template ""(.*)"" to ""(.*)""")]
        public void WhenICopyTheTemplate(
            string sourceLabel,
            string newLabel)
        {
            var sourceTemplateId = DomainHelper.Id<Template>(sourceLabel);
            var newTemplateId = DomainHelper.Id<Template>(newLabel);

            var cmd = new CopyTemplate(newTemplateId, sourceTemplateId, newLabel);
            DomainHelper.When(cmd);
        }

        [When(@"I copy the template")]
        public void WhenICopyTheTemplate()
        {
            var sourceTemplateId = DomainHelper.Id<Template>();
            var sourceCreated = DomainHelper
                .GetEventStream(sourceTemplateId)
                .OfType<TemplateCreated>()
                .Single();
            var sourceLabel = sourceCreated.Label;
            var copyLabel = string.Format("Copy of {0}", sourceLabel);
            WhenICopyTheTemplate(sourceLabel, copyLabel);
        }


        [When(@"I assign the instructor to the template")]
        public void WhenIAssignTheInstructorToTheTemplate()
        {
            var templateId = DomainHelper.Id<Template>();
            var instructorId = DomainHelper.Id<Instructor>();

            var cmd = new AssignInstructorToTemplate(templateId, instructorId);
            DomainHelper.When(cmd);

        }

        [When(@"I unassign the instructor from the template")]
        public void WhenIUnassignTheInstructorFromTheTemplate()
        {
            var templateId = DomainHelper.Id<Template>();

            var cmd = new UnassignInstructorFromTemplate(templateId);
            DomainHelper.When(cmd);
        }


        [When(@"I no longer require (\d+) ""(.*)"" per student for the template")]
        public void WhenINoLongerRequireEquipmentPerStudentForTheTemplate(
            string quantityString,
            string equipmentName)
        {
            WhenINoLongerRequireEquipmentPerStudentForTheTemplate(quantityString, equipmentName, "1");
        }

        [When(@"I no longer require (\d+) ""(.*)"" per (\d+) students for the template")]
        public void WhenINoLongerRequireEquipmentPerStudentForTheTemplate(
            string quantityString,
            string equipmentName,
            string perStudentsString)
        {
            var quantity = int.Parse(quantityString);
            var perStudent = int.Parse(perStudentsString);

            var templateId = DomainHelper.Id<Template>();

            var cmd = new RemoveTemplateStudentEquipment(
                templateId,
                equipmentName);
            DomainHelper.When(cmd);
        }

        [When(@"I no longer require (\d+) ""(.*)"" for the template")]
        public void WhenINoLongerRequireEquipmentForTheTemplate(
            string quantityString,
            string equipmentName)
        {
            var quantity = int.Parse(quantityString);
            var templateId = DomainHelper.Id<Template>();

            var cmd = new RemoveTemplateInstructorEquipment(
                templateId,
                quantity,
                equipmentName);
            DomainHelper.When(cmd);
        }

        [When(@"I require (\d+) ""(.*)"" per student for the template")]
        public void WhenIRequireEquipmentPerStudentForTheTemplate(
            string quantityString,
            string equipmentName)
        {
            WhenIRequireEquipmentPerStudentForTheTemplate(quantityString, equipmentName, "1");
        }

        [When(@"I require (\d+) ""(.*)"" per (\d+) students for the template")]
        public void WhenIRequireEquipmentPerStudentForTheTemplate(
            string quantityString,
            string equipmentName,
            string perStudentsString)
        {
            var quantity = int.Parse(quantityString);
            var perStudent = int.Parse(perStudentsString);

            var templateId = DomainHelper.Id<Template>();

            var cmd = new AddTemplateStudentEquipment(
                templateId,
                quantity,
                equipmentName,
                perStudent);
            DomainHelper.When(cmd);
        }

        [When(@"I require (\d+) ""(.*)"" for the template")]
        public void WhenIRequireEquipmentForTheTemplate(
            string quantityString,
            string equipmentName)
        {
            var quantity = int.Parse(quantityString);
            var templateId = DomainHelper.Id<Template>();

            var cmd = new AddTemplateInstructorEquipment(
                templateId,
                quantity,
                equipmentName);
            DomainHelper.When(cmd);
        }

    }
}
