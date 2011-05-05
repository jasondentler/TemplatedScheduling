using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{

    public class FacultyMapping : IMapping
    {
        private readonly CommandService _commandService;

        public FacultyMapping(CommandService commandService)
        {
            _commandService = commandService;
        }

        public void Register()
        {

            Map.Command<CreateFaculty>()
                .ToAggregateRoot<Faculty>()
                .CreateNew(cmd => new Faculty(cmd.FacultyId, cmd.FirstName, cmd.LastName))
                .RegisterWith(_commandService);

            Map.Command<ChangeFacultyName>()
                .ToAggregateRoot<Faculty>()
                .WithId(cmd => cmd.FacultyId)
                .ToCallOn((cmd, faculty) => faculty.ChangeName(cmd.NewFirstName, cmd.NewLastName))
                .RegisterWith(_commandService);

            Map.Command<AssignCourseToFaculty>()
                .ToAggregateRoot<Faculty>()
                .WithId(cmd => cmd.FacultyId)
                .ToCallOn((cmd, faculty) =>
                              {
                                  var ctx = UnitOfWorkContext.Current;
                                  var course = ctx.GetById<Course>(cmd.CourseId);
                                  faculty.AssignCourse(course);
                              })
                .RegisterWith(_commandService);

            Map.Command<UnassignCourseFromFaculty>()
                .ToAggregateRoot<Faculty>()
                .WithId(cmd => cmd.FacultyId)
                .ToCallOn((cmd, faculty) =>
                              {
                                  var ctx = UnitOfWorkContext.Current;
                                  var course = ctx.GetById<Course>(cmd.CourseId);
                                  faculty.UnassignCourse(course);
                              })
                .RegisterWith(_commandService);
        }
    }


}
