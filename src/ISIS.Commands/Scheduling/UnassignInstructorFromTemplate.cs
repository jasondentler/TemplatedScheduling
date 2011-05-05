using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class UnassignInstructorFromTemplate : CommandBase 
    {
        public Guid TemplateId { get; private set; }

        public UnassignInstructorFromTemplate(Guid templateId)
        {
            TemplateId = templateId;
        }
    }
}
