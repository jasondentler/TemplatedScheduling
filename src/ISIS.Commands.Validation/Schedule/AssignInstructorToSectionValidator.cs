using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class AssignInstructorToSectionValidator : AbstractValidator<AssignInstructorToSection>
    {

        public AssignInstructorToSectionValidator()
        {
            RuleFor(cmd => cmd.InstructorId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.SectionId)
                .NotEqual(default(Guid));
        }

    }
}
