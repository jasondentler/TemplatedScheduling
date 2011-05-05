using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class InstructorGiven
    {

        [Given(@"I create a new instructor with first name ""([^""]+)"" and last name ""([^""]+)""")]
        public void GivenICreateANewInstructor(
            string firstName,
            string lastName)
        {
            var instructorId = DomainHelper.Id<Instructor>(firstName, lastName);
            var @event = new InstructorCreated(instructorId, firstName, lastName);
            DomainHelper.Given<Instructor>(instructorId, @event);
        }

        [Given(@"I have created a instructor")]
        [Given(@"I have set up a new instructor")]
        [Given(@"I have created a new instructor")]
        public void GivenIHaveCreatedANewInstructor()
        {
            GivenICreateANewInstructor("John", "Smith");
        }


        [Given(@"I have assigned the course to the instructor")]
        public void GivenIHaveAssignedTheCourseToTheInstructor()
        {
            var instructorId = DomainHelper.Id<Instructor>();
            var courseId = DomainHelper.Id<Course>();
            var instructorCreated = DomainHelper.GetEventStream(instructorId).OfType<InstructorCreated>().Single();
            var courseCreated = DomainHelper.GetEventStream(courseId).OfType<CourseCreated>().Single();

            var @event = new InstructorAssignedCourse(
                instructorId, instructorCreated.FirstName, instructorCreated.LastName,
                courseId, courseCreated.Rubric, courseCreated.CourseNumber);
            DomainHelper.Given<Instructor>(@event);
        }

        [Given(@"I have unassigned the course from the instructor")]
        public void GivenIHaveUnassignedTheCourseFromTheInstructor()
        {
            var instructorId = DomainHelper.Id<Instructor>();
            var courseId = DomainHelper.Id<Course>();
            var instructorCreated = DomainHelper.GetEventStream(instructorId).OfType<InstructorCreated>().Single();
            var courseCreated = DomainHelper.GetEventStream(courseId).OfType<CourseCreated>().Single();

            var @event = new InstructorUnassignedCourse(
                instructorId, instructorCreated.FirstName, instructorCreated.LastName,
                courseId, courseCreated.Rubric, courseCreated.CourseNumber);
            DomainHelper.Given<Instructor>(@event);
        }



    }
}
