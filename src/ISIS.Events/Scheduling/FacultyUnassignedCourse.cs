using System;

namespace ISIS.Scheduling
{
    public class FacultyUnassignedCourse 
    {

        public Guid FacultyId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Guid CourseId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }

        public FacultyUnassignedCourse(Guid facultyId, string firstName, string lastName, Guid courseId, string rubric, string courseNumber)
        {
            FacultyId = facultyId;
            FirstName = firstName;
            LastName = lastName;
            CourseId = courseId;
            Rubric = rubric;
            CourseNumber = courseNumber;
        }
    }
}
