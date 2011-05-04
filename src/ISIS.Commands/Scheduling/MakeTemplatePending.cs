using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class MakeTemplatePending : CommandBase 
    {
        public Guid TemplateId { get; private set; }

        public MakeTemplatePending(Guid templateId)
        {
            TemplateId = templateId;
        }


    }
}
