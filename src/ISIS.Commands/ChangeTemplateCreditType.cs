using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{
    public class ChangeTemplateCreditType : CommandBase 
    {
        public Guid TemplateId { get; private set; }
        public CreditTypes CreditType { get; private set; }

        public ChangeTemplateCreditType(Guid templateId, CreditTypes creditType)
        {
            TemplateId = templateId;
            CreditType = creditType;
        }
    }
}
