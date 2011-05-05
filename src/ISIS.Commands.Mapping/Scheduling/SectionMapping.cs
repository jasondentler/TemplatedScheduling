using System;
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
                    var templateData = template.GetTemplateData();

                    var instructor = templateData.InstructorId == default(Guid)
                                      ? null
                                      : ctx.GetById<Instructor>(templateData.InstructorId);

                    return new Section(cmd.SectionId, templateData, instructor, cmd.SectionNumber);
                })
                .RegisterWith(_commandService);

            Map.Command<AssignInstructorToSection>()
                .ToAggregateRoot<Section>()
                .WithId(cmd => cmd.SectionId)
                .ToCallOn((cmd, section) =>
                              {
                                  var ctx = UnitOfWorkContext.Current;
                                  var instructor = ctx.GetById<Instructor>(cmd.InstructorId);
                                  section.AssignInstructor(instructor);
                              })
                .RegisterWith(_commandService);

            Map.Command<UnassignInstructorFromSection>()
                .ToAggregateRoot<Section>()
                .WithId(cmd => cmd.SectionId)
                .ToCallOn((cmd, section) => section.UnassignInstructor())
                .RegisterWith(_commandService);
        }
    }


}
