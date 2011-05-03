using System;
using ISIS.Domain;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Commands
{
    [MapsToAggregateRootMethod(typeof(Template), "MakeObsolete")]
    public class MakeTemplateObsolete : CommandBase 
    {
        [AggregateRootId]
        public Guid TemplateId { get; private set; }

        public MakeTemplateObsolete(Guid templateId)
        {
            TemplateId = templateId;
        }


    }
}
