using System;

namespace ISIS.Scheduling
{
    public class TemplateCopied
    {

        public Guid NewTemplateId { get; private set; }
        public string NewLabel { get; private set; }
        public Guid SourceTemplateId { get; private set; }
        public string SourceLabel { get; private set; }
        public Guid CourseId { get; private set; }
        public string Rubric { get; private set; }
        public string CourseNumber { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsContinuingEducation { get; private set; }
        public Guid TermId { get; private set; }
        public TemplateStatuses Status { get; private set; }

        public TemplateCopied(Guid newTemplateId, string newLabel, 
            Guid sourceTemplateId, string sourceLabel,
            Guid courseId, string rubric, string courseNumber, 
            string title, string description, bool isContinuingEducation,
            Guid termId, TemplateStatuses status)
        {
            NewTemplateId = newTemplateId;
            NewLabel = newLabel;
            SourceTemplateId = sourceTemplateId;
            SourceLabel = sourceLabel;
            CourseId = courseId;
            Rubric = rubric;
            CourseNumber = courseNumber;
            Title = title;
            Description = description;
            IsContinuingEducation = isContinuingEducation;
            TermId = termId;
            Status = status;
        }

    }
}
