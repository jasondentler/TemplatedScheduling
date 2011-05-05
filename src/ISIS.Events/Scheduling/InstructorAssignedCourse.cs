using System;

namespace ISIS.Scheduling
{
    public class InstructorAssignedCourse 
    {

        public Guid InstructorId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Guid CourseId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }

        public InstructorAssignedCourse(Guid instructorId, string firstName, string lastName, Guid courseId, string rubric, string courseNumber)
        {
            InstructorId = instructorId;
            FirstName = firstName;
            LastName = lastName;
            CourseId = courseId;
            Rubric = rubric;
            CourseNumber = courseNumber;
        }
    }
}
