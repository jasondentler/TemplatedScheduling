using ISIS.Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Domain;

namespace ISIS.Commands.Mapping
{

    public class TemplateMapping : IMapping
    {
        private readonly CommandService _commandService;

        public TemplateMapping(CommandService commandService)
        {
            _commandService = commandService;
        }

        public void Register()
        {
            Map.Command<CreateTemplate>()
                .ToAggregateRoot<Template>()
                .CreateNew(cmd =>
                               {
                                   var ctx = UnitOfWorkContext.Current;
                                   var course = ctx.GetById<Course>(cmd.CourseId);
                                   return new Template(cmd.TemplateId, course);
                               })
                .RegisterWith(_commandService);
        }
    }


}
