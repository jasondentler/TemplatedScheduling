using ISIS.Domain;
using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Commanding.CommandExecution.Mapping.Fluent;
using Ncqrs.Commanding.ServiceModel;

namespace ISIS.Commands.Mapping
{

    public class CourseMapping : IMapping
    {
        private readonly CommandService _commandService;

        public CourseMapping(CommandService commandService)
        {
            _commandService = commandService;
        }

        public void Register()
        {

            Map.Command<CreateCourse>()
                .ToAggregateRoot<Course>()
                .CreateNew(cmd => new Course(cmd.CourseId, cmd.Rubric, cmd.CourseNumber))
                .RegisterWith(_commandService);

            Map.Command<RenameCourse>()
                .ToAggregateRoot<Course>()
                .WithId(cmd => cmd.CourseId)
                .ToCallOn((cmd, course) => course.ChangeTitle(cmd.NewTitle, cmd.NewShortTitle))
                .RegisterWith(_commandService);

            Map.Command<ChangeCourseDescription>()
                .ToAggregateRoot<Course>()
                .WithId(cmd => cmd.CourseId)
                .ToCallOn((cmd, course) => course.ChangeDescription(cmd.Description))
                .RegisterWith(_commandService);

            Map.Command<ChangeCourseCIP>()
                .ToAggregateRoot<Course>()
                .WithId(cmd => cmd.CourseId)
                .ToCallOn((cmd, course) => course.ChangeCIP(cmd.CIP))
                .RegisterWith(_commandService);
        }
    }


}
