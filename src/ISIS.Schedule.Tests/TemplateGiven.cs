using System.Linq;
using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class TemplateGiven
    {

        [Given(@"I have created a template ""(.*)""")]
        [Given(@"I have created the template ""(.*)""")]
        public void GivenIHaveCreatedTheTemplate(
            string templateLabel)
        {
            var courseId = DomainHelper.Id<Course>();
            var templateId = DomainHelper.Id<Template>(templateLabel);
            var events = DomainHelper.GetEventStream(courseId);

            var courseCreatedEvent = events.OfType<CourseCreated>().Single();
            var courseTitleEvent = events.OfType<CourseRenamed>().Last();
            var courseDescriptionEvent = events.OfType<CourseDescriptionChanged>().Last();

            DomainHelper.Given<Template>(
                new TemplateCreated(templateId, templateLabel, courseId,
                                    courseCreatedEvent.Rubric, courseCreatedEvent.CourseNumber,
                                    courseTitleEvent.NewTitle,
                                    courseDescriptionEvent.NewDescription,
                                    courseCreatedEvent.IsContinuingEducation));
        }


        [Given(@"I have created a course and template")]
        [Given(@"I have set up a course and template")]
        public void GivenIHaveCreatedACourseAndTemplate()
        {
            var courseGiven = new CourseGiven();
            courseGiven.GivenIHaveSetUpANewCourse();
            GivenIHaveCreatedTheTemplate("Template Label");
        }

        [Given(@"I have set up a CE course and template")]
        [Given(@"I have created a CE course and template")]
        public void GivenIHaveCreatedACECourseAndTemplate()
        {
            var courseGiven = new CourseGiven();
            courseGiven.GivenIHaveSetUpANewCECourse();
            GivenIHaveCreatedTheTemplate("Template Label");
        }

        [Given(@"I have activated the template")]
        public void GivenIHaveActivatedTheTemplate()
        {
            var templateId = DomainHelper.Id<Template>();
            DomainHelper.Given<Template>(new TemplateActivated(templateId));
        }



        [Given(@"I have set up a course and template and I have activated the template")]
        [Given(@"I have set up a course and template and activated the template")]
        [Given(@"I have created a course and template and activated the template")]
        public void GivenIHaveCreatedACourseAndTemplateAndActivatedTheTemplate()
        {
            var termGiven = new TermGiven();

            GivenIHaveCreatedACourseAndTemplate();
            termGiven.GivenIHaveCreatedATerm();
            GivenIHaveAssignedTheTermToTheTemplate();
            GivenIHaveActivatedTheTemplate();
        }
        
        [Given(@"I have made the template pending")]
        public void GivenIHaveMadeTheTemplatePending()
        {
            var templateId = DomainHelper.Id<Template>();
            DomainHelper.Given<Template>(new TemplateMadePending(templateId));
        }

        [Given(@"I have deactivated a template")]
        public void GivenIHaveDeactivatedATemplate()
        {
            var templateId = DomainHelper.Id<Template>();
            DomainHelper.Given<Template>(new TemplateDeactivated(templateId));
        }

        [Given(@"I have made the template obsolete")]
        public void GivenIHaveMadeTheTemplateObsolete()
        {
            var templateId = DomainHelper.Id<Template>();
            DomainHelper.Given<Template>(new TemplateMadeObsolete(templateId));
        }

        [Given(@"I have assigned the term to the template")]
        public void GivenIHaveAssignedTheTermToTheTemplate()
        {
            var templateId = DomainHelper.Id<Template>();
            var termId = DomainHelper.Id<Term>();

            var e = DomainHelper.GetEventStream(termId).OfType<TermCreated>().Single();

            var @event = new TermAssignedToTemplate(templateId, termId,
                                                    e.Name, e.StartDate, e.EndDate);
            DomainHelper.Given<Template>(@event);
        }

        [Given(@"I have assigned the instructor to the template")]
        public void GivenIHaveAssignedTheInstructorToTheTemplate()
        {
            var instructorId = DomainHelper.Id<Instructor>();
            var templateId = DomainHelper.Id<Template>();

            var instructorCreated = DomainHelper.GetEventStream(instructorId).OfType<InstructorCreated>().Single();
            var templateCreated = DomainHelper.GetEventStream(templateId).OfType<TemplateCreated>().Single();

            var @event = new InstructorAssignedToTemplate(
                instructorId,
                instructorCreated.FirstName,
                instructorCreated.LastName,
                templateId,
                templateCreated.Label);

            DomainHelper.Given<Template>(@event);
        }


        [Given(@"I require (\d+) ""(.*)"" for the template")]
        public void GivenIRequireInstructorEquipmentForTheTemplate(
            string quantityString,
            string equipmentName)
        {
            var quantity = int.Parse(quantityString);
            var templateId = DomainHelper.Id<Template>();

            var templateEvents = DomainHelper.GetEventStream(templateId);
            var addedQuantity = templateEvents
                .OfType<InstructorEquipmentAddedToTemplate>()
                .Where(e => e.EquipmentName == equipmentName)
                .Sum(e => e.QuantityAdded);

            var subtractedQuantity = templateEvents
                .OfType<InstructorEquipmentRemovedFromTemplate>()
                .Where(e => e.EquipmentName == equipmentName)
                .Sum(e => e.QuantityRemoved);

            var currentQuantity = addedQuantity - subtractedQuantity;

            var @event = new InstructorEquipmentAddedToTemplate(
                templateId,
                quantity,
                equipmentName,
                currentQuantity + quantity);

            DomainHelper.Given<Template>(@event);
        }

        [Given(@"I require (\d+) ""(.*)"" per student for the template")]
        public void GivenIRequireEquipmentForTheTemplate(
            string quantityString,
            string equipmentName)
        {
            GivenIRequireEquipmentForTheTemplate(quantityString, equipmentName, "1");
        }


        [Given(@"I require (\d+) ""(.*)"" per (\d+) students for the template")]
        public void GivenIRequireEquipmentForTheTemplate(
            string quantityString,
            string equipmentName,
            string perStudentString)
        {
            var quantity = int.Parse(quantityString);
            var perStudent = int.Parse(perStudentString);

            var templateId = DomainHelper.Id<Template>();

            var @event = new StudentEquipmentAddedToTemplate(
                templateId,
                quantity,
                equipmentName,
                perStudent);

            DomainHelper.Given<Template>(@event);
        }


        
    }
}
