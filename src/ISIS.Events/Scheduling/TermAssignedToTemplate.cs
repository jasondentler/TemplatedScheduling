using System;

namespace ISIS.Scheduling
{
    public class TermAssignedToTemplate
    {
        public Guid TemplateId { get; private set; }
        public Guid TermId { get; private set; }
        public string TermName { get; private set; }
        public DateTime? StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public TermAssignedToTemplate(Guid templateId, Guid termId,
            string termName)
        {
            TemplateId = templateId;
            TermId = termId;
            TermName = termName;
        }

        public TermAssignedToTemplate(Guid templateId, Guid termId,
            string termName, 
            DateTime startDate,
            DateTime endDate)
        {
            TemplateId = templateId;
            TermId = termId;
            TermName = termName;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
