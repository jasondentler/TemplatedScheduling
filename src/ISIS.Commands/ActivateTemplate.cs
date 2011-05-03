using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Template), "Activate")]
    public class ActivateTemplate : CommandBase 
    {
        [AggregateRootId]
        public Guid TemplateId { get; private set; }

        public ActivateTemplate(Guid templateId)
        {
            TemplateId = templateId;
        }


    }
}
