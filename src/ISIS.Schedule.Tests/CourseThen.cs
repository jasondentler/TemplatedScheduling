using ISIS.Scheduling;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class CourseThen
    {
        [Then(@"the course is created")]
        public void ThenTheCourseIsCreated()
        {
            var e = DomainHelper.Then<CourseCreated>();
            e.CourseId.Should().Be.EqualTo(DomainHelper.Id<Course>());
            e.IsContinuingEducation.Should().Be.False();
        }

        [Then(@"the CE course is created")]
        public void ThenTheCECourseIsCreated()
        {
            var e = DomainHelper.Then<CourseCreated>();
            e.CourseId.Should().Be.EqualTo(DomainHelper.Id<Course>());
            e.IsContinuingEducation.Should().Be.True();
        }


        [Then(@"the course is renamed to ""([^""]*)""")]
        public void ThenTheCourseIsRenamedTo(
            string newTitle)
        {
            ThenTheCourseIsRenamedTo(newTitle, newTitle);
        }

        [Then(@"the course is renamed to ""([^""]*)"" with short title ""([^""]*)""")]
        public void ThenTheCourseIsRenamedTo(
            string newTitle,
            string newShortTitle)
        {
            ThenTheCourseIsRenamed(null, null, newTitle, newShortTitle);
        }
        
        [Then(@"the course is renamed from ""([^""]*)"" to ""([^""]*)""")]
        public void ThenTheCourseIsRenamedFromTo(
            string oldTitle,
            string newTitle)
        {
            ThenTheCourseIsRenamed(oldTitle, oldTitle, newTitle, newTitle);
        }

        [Then(@"the course is renamed from ""([^""]*)"" with short title ""([^""]*)"" to ""([^""]*)"" with short title ""([^""]*)""")]
        public void ThenTheCourseIsRenamed(
            string oldTitle,
            string oldShortTitle,
            string newTitle,
            string newShortTitle)
        {
            var e = DomainHelper.Then<CourseRenamed>();
            e.OldTitle.Should().Be.EqualTo(oldTitle);
            e.OldShortTitle.Should().Be.EqualTo(oldShortTitle);
            e.NewTitle.Should().Be.EqualTo(newTitle);
            e.NewShortTitle.Should().Be.EqualTo(newShortTitle);
        }

        [Then(@"the course description is changed from ""(.*)"" to ""(.*)""")]
        public void ThenTheCourseDescriptionIsChanged(
            string oldDescription,
            string newDescription)
        {
            var e = DomainHelper.Then<CourseDescriptionChanged>();
            e.OldDescription.Should().Be.EqualTo(oldDescription);
            e.NewDescription.Should().Be.EqualTo(newDescription);
        }

        [Then(@"the course description is set to ""(.*)""")]
        public void ThenTheCourseDescriptionIsSetTo(
            string newDescription)
        {
            var e = DomainHelper.Then<CourseDescriptionChanged>();
            e.OldDescription.Should().Be.NullOrEmpty();
            e.NewDescription.Should().Be.EqualTo(newDescription);
        }

        [Then(@"(\d+) ""(.*)"" per student is no longer required for the course")]
        public void ThenEquipmentIsNoLongerRequiredForTheCourse(
            string quantityString,
            string equipmentName)
        {
            ThenEquipmentIsNoLongerRequiredForTheCourse(quantityString, equipmentName, "1");
        }

        [Then(@"(\d+) ""(.*)"" per (\d+) students is no longer required for the course")]
        public void ThenEquipmentIsNoLongerRequiredForTheCourse(
            string quantityString,
            string equipmentName,
            string perStudentString)
        {
            var courseId = DomainHelper.Id<Course>();

            var e = DomainHelper.Then<StudentEquipmentRemovedFromCourse>();
            e.CourseId.Should().Be.EqualTo(courseId);
            e.EquipmentName.Should().Be.EqualTo(equipmentName);
        }

        [Then(@"(\d+) ""(.*)"" is no longer required for the course, for a total of (\d+)")]
        public void ThenInstructorEquipmentIsNoLongerRequiredForTheCourse(
            string quantityString,
            string equipmentName,
            string totalString)
        {
            var courseId = DomainHelper.Id<Course>();
            var quantity = int.Parse(quantityString);
            var total = int.Parse(totalString);

            var e = DomainHelper.Then<InstructorEquipmentRemovedFromCourse>();
            e.CourseId.Should().Be.EqualTo(courseId);
            e.EquipmentName.Should().Be.EqualTo(equipmentName);
            e.QuantityRemoved.Should().Be.EqualTo(quantity);
            e.TotalRequired.Should().Be.EqualTo(total);
        }

        [Then(@"(\d+) ""(.*)"" per student is required for the course")]
        public void ThenEquipmentIsRequiredForTheCourse(
            string quantityString,
            string equipmentName)
        {
            ThenEquipmentIsRequiredForTheCourse(quantityString, equipmentName, "1");
        }

        [Then(@"(\d+) ""(.*)"" per (\d+) students is required for the course")]
        public void ThenEquipmentIsRequiredForTheCourse(
            string quantityString,
            string equipmentName,
            string perStudentString)
        {
            var courseId = DomainHelper.Id<Course>();
            var quantity = int.Parse(quantityString);
            var perStudent = int.Parse(perStudentString);

            var e = DomainHelper.Then<StudentEquipmentAddedToCourse>();
            e.CourseId.Should().Be.EqualTo(courseId);
            e.EquipmentName.Should().Be.EqualTo(equipmentName);
            e.Quantity.Should().Be.EqualTo(quantity);
            e.PerStudent.Should().Be.EqualTo(perStudent);
        }

        [Then(@"(\d+) ""(.*)"" is required for the course, for a total of (\d+)")]
        public void ThenInstructorEquipmentIsRequiredForTheCourse(
            string quantityString,
            string equipmentName,
            string totalString)
        {
            var courseId = DomainHelper.Id<Course>();
            var quantity = int.Parse(quantityString);
            var total = int.Parse(totalString);

            var e = DomainHelper.Then<InstructorEquipmentAddedToCourse>();
            e.CourseId.Should().Be.EqualTo(courseId);
            e.EquipmentName.Should().Be.EqualTo(equipmentName);
            e.QuantityAdded.Should().Be.EqualTo(quantity);
            e.TotalRequired.Should().Be.EqualTo(total);
        }



    }
}
