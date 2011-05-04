using System;

namespace ISIS.Scheduling
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
