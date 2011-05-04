using ISIS.Commands;
using ISIS.Commands.Mapping;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{

    public class SectionMapping : IMapping
    {
        private readonly CommandService _commandService;

        public SectionMapping(CommandService commandService)
        {
            _commandService = commandService;
        }

        public void Register()
        {

            Map.Command<CreateSection>()
                .ToAggregateRoot<Section>()
                .CreateNew(cmd =>
                {
                    var ctx = UnitOfWorkContext.Current;
                    var template = ctx.GetById<Template>(cmd.TemplateId);
                    return new Section(cmd.SectionId, template, cmd.SectionNumber);
                })
                .RegisterWith(_commandService);

        }
    }


}
