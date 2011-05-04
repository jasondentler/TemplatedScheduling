using System;

namespace ISIS.Scheduling
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
