using System.Linq;
using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class CourseGiven
    {
        [Given(@"I have created a new course ([A-Z]{4}) (\d{4})")]
        public void GivenIHaveCreatedANewCourse(
            string rubric,
            string number)
        {
            var creditHours = number.Substring(1, 1);
            var isCE = int.Parse(creditHours) == 0;
            var courseId = DomainHelper.Id<Course>(rubric, number);
            DomainHelper.Given<Course>(new CourseCreated(courseId, rubric, number, isCE));
        }

        [Given(@"I have created a new course")]
        [Given(@"I have created a course")]
        public void GivenIHaveCreatedANewCourse()
        {
            GivenIHaveCreatedANewCourse("BIOL", "1301");
        }

        [Given(@"I have renamed the course to ""([^""]*)""")]
        public void GivenIHaveRenamedTheCourseTo(
            string newTitle)
        {
            GivenIHaveRenamedTheCourseTo(newTitle, newTitle);
        }

        [Given(@"I have renamed the course to ""([^""]*)"" with short title ""([^""]*)""")]
        public void GivenIHaveRenamedTheCourseTo(
            string newTitle,
            string newShortTitle)
        {
            var courseId = DomainHelper.Id<Course>();
            var renameEvents = DomainHelper.GetEventStream(courseId)
                .OfType<CourseRenamed>();

            var oldTitle = renameEvents.Select(e => e.NewTitle).LastOrDefault();
            var oldShortTitle = renameEvents.Select(e => e.NewShortTitle).LastOrDefault();
            DomainHelper.Given<Course>(new CourseRenamed(courseId,
                                                         oldTitle, newTitle,
                                                         oldShortTitle, newShortTitle));
        }

        [Given(@"I have changed the course description to ""(.*)""")]
        [Given(@"I have set the course description to ""(.*)""")]
        public void GivenIHaveChangedTheCourseDescriptionTo(
            string description)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.Given<Course>(new CourseDescriptionChanged(
                                           courseId,
                                           null,
                                           description));
        }


        [Given(@"I have set up a course")]
        [Given(@"I have set up a new course")]
        public void GivenIHaveSetUpANewCourse()
        {
            GivenIHaveCreatedANewCourse("BIOL", "1301");
            GivenIHaveRenamedTheCourseTo("Introductory Biology");
            GivenIHaveChangedTheCourseDescriptionTo("Cuttin' up frogs");
        }

        [Given(@"I have set up a new CE course")]
        public void GivenIHaveSetUpANewCECourse()
        {
            GivenIHaveCreatedANewCourse("BIOL", "1001");
            GivenIHaveRenamedTheCourseTo("Biology for Continuing Education");
            GivenIHaveChangedTheCourseDescriptionTo("Cuttin' up frogs");
        }

        [Given(@"I require (\d+) ""(.*)"" for the course")]
        public void GivenIRequireInstructorEquipmentForTheCourse(
            string quantityString,
            string equipmentName)
        {
            var quantity = int.Parse(quantityString);
            var courseId = DomainHelper.Id<Course>();

            var courseEvents = DomainHelper.GetEventStream(courseId);
            var addedQuantity = courseEvents
                .OfType<InstructorEquipmentAddedToCourse>()
                .Where(e => e.EquipmentName == equipmentName)
                .Sum(e => e.QuantityAdded);

            var subtractedQuantity = courseEvents
                .OfType<InstructorEquipmentRemovedFromCourse>()
                .Where(e => e.EquipmentName == equipmentName)
                .Sum(e => e.QuantityRemoved);

            var currentQuantity = addedQuantity - subtractedQuantity;

            var @event = new InstructorEquipmentAddedToCourse(
                courseId,
                quantity,
                equipmentName,
                currentQuantity + quantity);

            DomainHelper.Given<Course>(@event);
        }

        [Given(@"I require (\d+) ""(.*)"" per student for the course")]
        public void GivenIRequireEquipmentForTheCourse(
            string quantityString,
            string equipmentName)
        {
            GivenIRequireEquipmentForTheCourse(quantityString, equipmentName, "1");
        }


        [Given(@"I require (\d+) ""(.*)"" per (\d+) students for the course")]
        public void GivenIRequireEquipmentForTheCourse(
            string quantityString,
            string equipmentName,
            string perStudentString)
        {
            var quantity = int.Parse(quantityString);
            var perStudent = int.Parse(perStudentString);

            var courseId = DomainHelper.Id<Course>();

            var @event = new StudentEquipmentAddedToCourse(
                courseId,
                quantity,
                equipmentName,
                perStudent);

            DomainHelper.Given<Course>(@event);
        }



    }
}
