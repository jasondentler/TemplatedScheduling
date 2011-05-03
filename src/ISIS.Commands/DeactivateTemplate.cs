using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{

    public class DeactivateTemplate : CommandBase 
    {

        public Guid TemplateId { get; private set; }

        public DeactivateTemplate(Guid templateId)
        {
            TemplateId = templateId;
        }


    }
}
