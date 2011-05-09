using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class AssignInstructorToTemplateValidator : AbstractValidator<AssignInstructorToTemplate>
    {

        public AssignInstructorToTemplateValidator()
        {
            RuleFor(cmd => cmd.InstructorId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.TemplateId)
                .NotEqual(default(Guid));
        }

    }
}
