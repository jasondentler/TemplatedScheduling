using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{

    public class CopyTemplate : CommandBase 
    {
        public Guid NewTemplateId { get; private set; }
        public Guid SourceTemplateId { get; private set; }
        public string NewTemplateLabel { get; private set; }

        public CopyTemplate(Guid newTemplateId, Guid sourceTemplateId, string newTemplateLabel)
        {
            NewTemplateId = newTemplateId;
            SourceTemplateId = sourceTemplateId;
            NewTemplateLabel = newTemplateLabel;
        }
    }
}
