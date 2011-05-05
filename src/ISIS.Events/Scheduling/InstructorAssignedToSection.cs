using System;

namespace ISIS.Scheduling
{

    public class InstructorAssignedToSection 
    {
        public Guid SectionId { get; private set; }
        public Guid CourseId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }
        public string SectionNumber { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid InstructorId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public InstructorAssignedToSection(
            Guid sectionId,
            Guid courseId, 
            string rubric,
            string courseNumber,
            string sectionNumber,
            string title,
            string description,
            Guid instructorId,
            string firstName,
            string lastName)
        {
            SectionId = sectionId;
            CourseId = courseId;
            Rubric = rubric;
            CourseNumber = courseNumber;
            SectionNumber = sectionNumber;
            Title = title;
            Description = description;
            InstructorId = instructorId;
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
