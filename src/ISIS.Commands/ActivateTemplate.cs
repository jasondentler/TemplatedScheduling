using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{

    public class ActivateTemplate : CommandBase 
    {

        public Guid TemplateId { get; private set; }

        public ActivateTemplate(Guid templateId)
        {
            TemplateId = templateId;
        }


    }
}
