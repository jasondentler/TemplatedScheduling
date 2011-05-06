using System;
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

            Map.Command<CopyTemplate>()
                .ToAggregateRoot<Template>()
                .CreateNew(cmd =>
                               {
                                   var ctx = UnitOfWorkContext.Current;
                                   var source = ctx.GetById<Template>(cmd.SourceTemplateId);
                                   var sourceData = source.GetTemplateData();

                                   var term = sourceData.TermId == default(Guid)
                                                  ? null
                                                  : ctx.GetById<Term>(sourceData.TermId);

                                   var course = sourceData.CourseId == default(Guid)
                                                    ? null
                                                    : ctx.GetById<Course>(sourceData.CourseId);

                                   var instructor = sourceData.InstructorId == default(Guid)
                                                     ? null
                                                     : ctx.GetById<Instructor>(sourceData.InstructorId);

                                   return new Template(cmd.NewTemplateId, cmd.NewTemplateLabel, sourceData, term, course,
                                                       instructor);
                               })
                .RegisterWith(_commandService);

            Map.Command<AssignInstructorToTemplate>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) =>
                              {
                                  var ctx = UnitOfWorkContext.Current;
                                  var instructor = ctx.GetById<Instructor>(cmd.InstructorId);
                                  template.AssignInstructor(instructor);
                              })
                .RegisterWith(_commandService);

            Map.Command<UnassignInstructorFromTemplate>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) => template.UnassignInstructor())
                .RegisterWith(_commandService);



            Map.Command<AddTemplateInstructorEquipment>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) => template.AddInstructorEquipment(cmd.Quantity, cmd.EquipmentName))
                .RegisterWith(_commandService);

            Map.Command<AddTemplateStudentEquipment>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) => template.AddStudentEquipment(cmd.Quantity, cmd.PerStudent, cmd.EquipmentName))
                .RegisterWith(_commandService);

            Map.Command<RemoveTemplateInstructorEquipment>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) => template.RemoveInstructorEquipment(cmd.Quantity, cmd.EquipmentName))
                .RegisterWith(_commandService);

            Map.Command<RemoveTemplateStudentEquipment>()
                .ToAggregateRoot<Template>()
                .WithId(cmd => cmd.TemplateId)
                .ToCallOn((cmd, template) => template.RemoveStudentEquipment(cmd.EquipmentName))
                .RegisterWith(_commandService);

        }
    }


}
