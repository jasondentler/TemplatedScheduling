using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{

    public class InstructorMapping : IMapping
    {
        private readonly CommandService _commandService;

        public InstructorMapping(CommandService commandService)
        {
            _commandService = commandService;
        }

        public void Register()
        {

            Map.Command<CreateInstructor>()
                .ToAggregateRoot<Instructor>()
                .CreateNew(cmd => new Instructor(cmd.InstructorId, cmd.FirstName, cmd.LastName))
                .RegisterWith(_commandService);

            Map.Command<ChangeInstructorName>()
                .ToAggregateRoot<Instructor>()
                .WithId(cmd => cmd.InstructorId)
                .ToCallOn((cmd, instructor) => instructor.ChangeName(cmd.NewFirstName, cmd.NewLastName))
                .RegisterWith(_commandService);

            Map.Command<AssignCourseToInstructor>()
                .ToAggregateRoot<Instructor>()
                .WithId(cmd => cmd.InstructorId)
                .ToCallOn((cmd, instructor) =>
                              {
                                  var ctx = UnitOfWorkContext.Current;
                                  var course = ctx.GetById<Course>(cmd.CourseId);
                                  instructor.AssignCourse(course);
                              })
                .RegisterWith(_commandService);

            Map.Command<UnassignCourseFromInstructor>()
                .ToAggregateRoot<Instructor>()
                .WithId(cmd => cmd.InstructorId)
                .ToCallOn((cmd, instructor) =>
                              {
                                  var ctx = UnitOfWorkContext.Current;
                                  var course = ctx.GetById<Course>(cmd.CourseId);
                                  instructor.UnassignCourse(course);
                              })
                .RegisterWith(_commandService);
        }
    }


}
