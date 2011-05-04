using ISIS.Commands;
using ISIS.Commands.Mapping;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Domain;

namespace ISIS.Scheduling
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
                                   return new Template(cmd.TemplateId, cmd.Label, course);
                               })
                .RegisterWith(_commandService);

            Map.Command<RenameTemplate>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) => template.Rename(cmd.NewLabel))
                .RegisterWith(_commandService);

            Map.Command<ActivateTemplate>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) => template.Activate())
                .RegisterWith(_commandService);

            Map.Command<MakeTemplatePending>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) => template.MakePending())
                .RegisterWith(_commandService);

            Map.Command<DeactivateTemplate>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) => template.Deactivate())
                .RegisterWith(_commandService);

            Map.Command<MakeTemplateObsolete>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) => template.MakeObsolete())
                .RegisterWith(_commandService);
            
            Map.Command<AssignTermToTemplate>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) =>
                              {
                                  var ctx = UnitOfWorkContext.Current;
                                  var term = ctx.GetById<Term>(cmd.TermId);
                                  template.AssignTerm(term);
                              })
                .RegisterWith(_commandService);

        }
    }


}
