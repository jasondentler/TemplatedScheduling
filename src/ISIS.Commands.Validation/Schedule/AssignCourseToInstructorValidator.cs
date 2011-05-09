using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class AssignCourseToInstructorValidator : AbstractValidator<AssignCourseToInstructor>
    {

        public AssignCourseToInstructorValidator()
        {
            RuleFor(cmd => cmd.InstructorId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.CourseId)
                .NotEqual(default(Guid));
        }

    }
}
