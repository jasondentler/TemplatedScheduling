using System.Linq;
using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class SectionGiven
    {

        [Given(@"I have set up a new course, template, instructor, and section")]
        public void GivenIHaveSetUpANewCourseTemplateInstructorAndSection()
        {
            var templateGiven = new TemplateGiven();
            templateGiven.GivenIHaveCreatedACourseAndTemplateAndActivatedTheTemplate();

            var instructorGiven = new InstructorGiven();
            instructorGiven.GivenIHaveCreatedANewInstructor();
            instructorGiven.GivenIHaveAssignedTheCourseToTheInstructor();

            var templateId = DomainHelper.Id<Template>();
            var sectionId = DomainHelper.Id<Section>();
            var termId = DomainHelper.Id<Term>();

            var templateCreated = DomainHelper.GetEventStream(templateId).OfType<TemplateCreated>().Single();

            var @event = new SectionCreated(
                sectionId,
                templateId,
                templateCreated.CourseId,
                termId,
                templateCreated.Rubric,
                templateCreated.CourseNumber,
                "01",
                templateCreated.Title,
                templateCreated.Description);

            DomainHelper.Given<Section>(@event);
        }

        [Given(@"I have assigned the instructor to the section")]
        public void GivenIHaveAssignedTheInstructorToTheSection()
        {
            var sectionId = DomainHelper.Id<Section>();
            var instructorId = DomainHelper.Id<Instructor>();

            var sectionCreated = DomainHelper.GetEventStream(sectionId).OfType<SectionCreated>().Single();
            var instructorCreated = DomainHelper.GetEventStream(instructorId).OfType<InstructorCreated>().Single();

            var @event = new InstructorAssignedToSection(
                sectionId,
                sectionCreated.CourseId,
                sectionCreated.Rubric,
                sectionCreated.CourseNumber,
                sectionCreated.SectionNumber,
                sectionCreated.Title,
                sectionCreated.Description,
                instructorId,
                instructorCreated.FirstName,
                instructorCreated.LastName);

            DomainHelper.Given<Section>(@event);
        }


    }
}
