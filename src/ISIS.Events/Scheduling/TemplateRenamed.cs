using System;

namespace ISIS.Scheduling
{
    public class TemplateRenamed
    {

        public Guid TemplateId { get; private set; }
        public string OldLabel { get; private set; }
        public string NewLabel { get; private set; }

        public TemplateRenamed(Guid templateId, string oldLabel, string newLabel)
        {
            TemplateId = templateId;
            OldLabel = oldLabel;
            NewLabel = newLabel;
        }
    }
}
