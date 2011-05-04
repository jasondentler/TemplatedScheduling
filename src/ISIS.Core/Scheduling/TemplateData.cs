using System;

namespace ISIS.Scheduling
{

    public struct TemplateData
    {

        public Guid TemplateId;
        public Guid CourseId;
        public string Rubric;
        public string CourseNumber;
        public string Title;
        public string Description;
        public bool IsContinuingEducation;
        public TemplateStatuses Status;
    }

}
