using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Template), "Deactivate")]
    public class DeactivateTemplate : CommandBase 
    {
        [AggregateRootId]
        public Guid TemplateId { get; private set; }

        public DeactivateTemplate(Guid templateId)
        {
            TemplateId = templateId;
        }


    }
}
