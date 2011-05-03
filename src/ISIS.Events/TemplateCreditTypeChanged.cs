using System;

namespace ISIS.Events
{
    public class TemplateCreditTypeChanged
    {

        public Guid TemplateId { get; private set; }
        public CreditTypes CreditType { get; private set; }

        public TemplateCreditTypeChanged(Guid templateId, CreditTypes creditType)
        {
            TemplateId = templateId;
            CreditType = creditType;
        }
    }
}
