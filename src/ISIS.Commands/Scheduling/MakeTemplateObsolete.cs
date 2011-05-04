using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class MakeTemplateObsolete : CommandBase 
    {
        public Guid TemplateId { get; private set; }

        public MakeTemplateObsolete(Guid templateId)
        {
            TemplateId = templateId;
        }


    }
}
