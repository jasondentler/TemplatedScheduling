using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class CourseWhen
    {

        [When(@"I create a new course ([A-Z]{4}) (\d{4})")]
        public void WhenICreateANewCourse(
            string rubric,
            string number)
        {
            var courseId = DomainHelper.Id<Course>(rubric, number);
            DomainHelper.When(new CreateCourse(courseId, rubric, number));
        }

        [When(@"I rename the course to ""([^""]*)""")]
        public void WhenIChangeTheCourseTitleTo(
            string newTitle)
        {
            WhenIRenameTheCourseTo(newTitle, newTitle);
        }

        [When(@"I rename the course to ""([^""]*)"" with short title ""([^""]*)""")]
        public void WhenIRenameTheCourseTo(
            string newTitle,
            string newShortTitle)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.When(new RenameCourse(courseId, newTitle, newShortTitle));
        }

        [When(@"I change the course description to ""(.*)""")]
        public void WhenIChangeTheCourseDescriptionTo(
            string newDescription)
        {
            var courseId = DomainHelper.Id<Course>();
            DomainHelper.When(new ChangeCourseDescription(
                courseId,
                newDescription));
        }

        [When(@"I no longer require (\d+) ""(.*)"" per student for the course")]
        public void WhenINoLongerRequireEquipmentPerStudentForTheCourse(
            string quantityString,
            string equipmentName)
        {
            WhenINoLongerRequireEquipmentPerStudentForTheCourse(quantityString, equipmentName, "1");
        }

        [When(@"I no longer require (\d+) ""(.*)"" per (\d+) students for the course")]
        public void WhenINoLongerRequireEquipmentPerStudentForTheCourse(
            string quantityString,
            string equipmentName,
            string perStudentsString)
        {
            var quantity = int.Parse(quantityString);
            var perStudent = int.Parse(perStudentsString);

            var courseId = DomainHelper.Id<Course>();

            var cmd = new RemoveCourseStudentEquipment(
                courseId,
                equipmentName);
            DomainHelper.When(cmd);
        }

        [When(@"I no longer require (\d+) ""(.*)"" for the course")]
        public void WhenINoLongerRequireEquipmentForTheCourse(
            string quantityString,
            string equipmentName)
        {
            var quantity = int.Parse(quantityString);
            var courseId = DomainHelper.Id<Course>();

            var cmd = new RemoveCourseInstructorEquipment(
                courseId,
                quantity,
                equipmentName);
            DomainHelper.When(cmd);
        }

        [When(@"I require (\d+) ""(.*)"" per student for the course")]
        public void WhenIRequireEquipmentPerStudentForTheCourse(
            string quantityString,
            string equipmentName)
        {
            WhenIRequireEquipmentPerStudentForTheCourse(quantityString, equipmentName, "1");
        }

        [When(@"I require (\d+) ""(.*)"" per (\d+) students for the course")]
        public void WhenIRequireEquipmentPerStudentForTheCourse(
            string quantityString,
            string equipmentName,
            string perStudentsString)
        {
            var quantity = int.Parse(quantityString);
            var perStudent = int.Parse(perStudentsString);

            var courseId = DomainHelper.Id<Course>();

            var cmd = new AddCourseStudentEquipment(
                courseId,
                quantity,
                equipmentName,
                perStudent);
            DomainHelper.When(cmd);
        }

        [When(@"I require (\d+) ""(.*)"" for the course")]
        public void WhenIRequireEquipmentForTheCourse(
            string quantityString,
            string equipmentName)
        {
            var quantity = int.Parse(quantityString);
            var courseId = DomainHelper.Id<Course>();

            var cmd = new AddCourseInstructorEquipment(
                courseId,
                quantity,
                equipmentName);
            DomainHelper.When(cmd);
        }





    }
}
