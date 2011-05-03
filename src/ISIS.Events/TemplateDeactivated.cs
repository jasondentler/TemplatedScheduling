using System;

namespace ISIS.Events
{
    public class TemplateDeactivated
    {

        public Guid TemplateId { get; private set; }

        public TemplateDeactivated(Guid templateId)
        {
            TemplateId = templateId;
        }
    }
}
