using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class UnassignFacultyFromTemplate : CommandBase 
    {
        public Guid TemplateId { get; private set; }

        public UnassignFacultyFromTemplate(Guid templateId)
        {
            TemplateId = templateId;
        }
    }
}
