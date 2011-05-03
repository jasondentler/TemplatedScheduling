using System;

namespace ISIS.Events
{
    public class TemplateMadePending
    {

        public Guid TemplateId { get; private set; }

        public TemplateMadePending(Guid templateId)
        {
            TemplateId = templateId;
        }
    }
}
