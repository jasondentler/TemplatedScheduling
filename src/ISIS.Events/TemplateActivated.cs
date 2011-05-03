using System;

namespace ISIS.Events
{
    public class TemplateActivated
    {

        public Guid TemplateId { get; private set; }

        public TemplateActivated(Guid templateId)
        {
            TemplateId = templateId;
        }
    }
}
