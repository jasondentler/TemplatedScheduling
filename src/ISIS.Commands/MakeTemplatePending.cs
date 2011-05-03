using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Template), "MakePending")]
    public class MakeTemplatePending : CommandBase 
    {
        [AggregateRootId]
        public Guid TemplateId { get; private set; }

        public MakeTemplatePending(Guid templateId)
        {
            TemplateId = templateId;
        }


    }
}
