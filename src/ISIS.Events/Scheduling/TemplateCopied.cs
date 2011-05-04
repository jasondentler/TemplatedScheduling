using System;

namespace ISIS.Scheduling
{
    public class TemplateCopied
    {

        public Guid NewTemplateId { get; private set; }
        public string NewLabel { get; private set; }
        public Guid SourceTemplateId { get; private set; }
        public string SourceLabel { get; private set; }

        public TemplateCopied(Guid newTemplateId, string newLabel,
            Guid sourceTemplateId, string sourceLabel)
        {
            NewTemplateId = newTemplateId;
            NewLabel = newLabel;
            SourceTemplateId = sourceTemplateId;
            SourceLabel = sourceLabel;
        }

    }
}
