using System.Linq;
using ISIS.Events;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class TemplateGiven
    {

        [Given(@"I have created the template ""(.*)""")]
        public void GivenIHaveCreatedTheTemplate(
            string templateLabel)
        {
            var courseId = DomainHelper.Id<Course>();
            var templateId = DomainHelper.Id<Template>(templateLabel);
            var events = DomainHelper.GetEventStream(courseId);

            var courseCreatedEvent = events.OfType<CourseCreated>().Single();
            var courseTitleEvent = events.OfType<CourseRenamed>().Last();
            var courseCIPEvent = events.OfType<CourseCIPChanged>().Last();
            var courseDescriptionEvent = events.OfType<CourseDescriptionChanged>().Last();

            DomainHelper.Given<Template>(
                new TemplateCreated(templateId, templateLabel, courseId,
                                    courseCreatedEvent.Rubric, courseCreatedEvent.CourseNumber,
                                    courseTitleEvent.NewTitle,
                                    courseCIPEvent.NewCIP,
                                    courseDescriptionEvent.NewDescription,
                                    courseCreatedEvent.IsContinuingEducation));
        }


        [Given(@"I have created a course and template")]
        public void GivenIHaveCreatedACourseAndTemplate()
        {
            var courseGiven = new CourseGiven();
            courseGiven.GivenIHaveSetUpANewCourse();
            GivenIHaveCreatedTheTemplate("Template Label");
        }

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

        [Given(@"I have created a course and template and activated the template")]
        public void GivenIHaveCreatedACourseAndTemplateAndActivatedTheTemplate()
        {
            GivenIHaveCreatedACourseAndTemplate();
            GivenIHaveActivatedTheTemplate();
        }
        
        [Given(@"I make the template pending")]
        public void GivenIMakeTheTemplatePending()
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

        [Given(@"I have changed the template's credit type to ""(.*)""")]
        public void GivenIHaveChangedTheTemplateSCreditTypeTo(
            string creditTypeString)
        {
            var map = new EnumData<CreditTypes>().GetReverseDictionary();
            var creditType = (CreditTypes)map[creditTypeString];
            var templateId = DomainHelper.Id<Template>();
            var @event = new TemplateCreditTypeChanged(templateId, creditType);
            DomainHelper.Given<Template>(@event);
        }


        [Given(@"I have changed the template's course type to ""(.*)""")]
        public void GivenIHaveChangedTheTemplateSCourseTypeTo(
            string courseTypeString)
        {
            var map = new EnumData<CourseTypes>().GetReverseDictionary();
            var courseType = (CourseTypes)map[courseTypeString];
            var templateId = DomainHelper.Id<Template>();
            var @event = new TemplateCourseTypeChanged(templateId, courseType);
            DomainHelper.Given<Template>(@event);
        }


    }
}
