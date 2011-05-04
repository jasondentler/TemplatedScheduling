using System;

namespace ISIS.Scheduling
{
    public class TemplateCreated
    {

        public Guid TemplateId { get; private set; }
        public string Label { get; private set; }
        public Guid CourseId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsContinuingEducation { get; private set; }

        public TemplateCreated(Guid templateId, string label, Guid courseId, 
            string rubric, string courseNumber, string title,
            string description, bool isContinuingEducation)
        {
            TemplateId = templateId;
            Label = label;
            CourseId = courseId;
            Rubric = rubric;
            CourseNumber = courseNumber;
            Title = title;
            Description = description;
            IsContinuingEducation = isContinuingEducation;
        }

   }
}
