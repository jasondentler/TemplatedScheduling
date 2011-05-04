using System;

namespace ISIS.Scheduling
{
    public class SectionCreated
    {
        public Guid SectionId { get; private set; }
        public Guid TemplateId { get; private set; }
        public Guid CourseId { get; private set; }
        public Guid TermId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }
        public string SectionNumber { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public SectionCreated(
            Guid sectionId, 
            Guid templateId,
            Guid courseId,
            Guid termId,
            string rubric,
            string courseNumber,
            string sectionNumber,
            string title,
            string description)
        {
            SectionId = sectionId;
            TemplateId = templateId;
            CourseId = courseId;
            TermId = termId;
            Rubric = rubric;
            CourseNumber = courseNumber;
            SectionNumber = sectionNumber;
            Title = title;
            Description = description;
        }
    }
}
