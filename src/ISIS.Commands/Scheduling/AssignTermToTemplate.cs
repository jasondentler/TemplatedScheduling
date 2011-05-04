using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class AssignTermToTemplate : CommandBase 
    {
        public Guid TemplateId { get; private set; }
        public Guid TermId { get; private set; }

        public AssignTermToTemplate(Guid templateId, Guid termId)
        {
            TemplateId = templateId;
            TermId = termId;
        }
    }
}
