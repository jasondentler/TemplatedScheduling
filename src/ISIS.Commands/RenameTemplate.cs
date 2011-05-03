using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{

    public class RenameTemplate : CommandBase 
    {
        public Guid TemplateId { get; set; }
        public string NewLabel { get; set; }

        public RenameTemplate(Guid templateId, string newLabel)
        {
            TemplateId = templateId;
            NewLabel = newLabel;
        }
    }

}
