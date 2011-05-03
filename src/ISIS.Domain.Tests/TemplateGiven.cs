using System.Linq;
using ISIS.Events;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class TemplateGiven
    {

        [Given(@"I have created a course and template")]
        public void GivenIHaveCreatedACourseAndTemplate()
        {
            const string cip = "12.3456";
            const string description = "Description goes here";
            var courseGiven = new CourseGiven();
            courseGiven.GivenIHaveCreatedANewCourse();
            courseGiven.GivenIHaveChangedTheCourseCIPTo(cip);
            courseGiven.GivenIHaveChangedTheCourseDescriptionTo(description);

            var courseId = DomainHelper.Id<Course>();
            var templateId = DomainHelper.Id<Template>();

            var courseCreatedEvent = DomainHelper.GetEventStream(courseId)
                .OfType<CourseCreated>().Single();

            DomainHelper.Given<Template>(
                new TemplateCreated(templateId, courseId,
                                    courseCreatedEvent.Rubric, courseCreatedEvent.CourseNumber,
                                    courseCreatedEvent.Title,
                                    cip,
                                    description));

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

    }
}
