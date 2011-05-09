using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class AssignTermToTemplateValidator : AbstractValidator<AssignTermToTemplate>
    {

        public AssignTermToTemplateValidator()
        {
            RuleFor(cmd => cmd.TermId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.TemplateId)
                .NotEqual(default(Guid));
        }

    }
}
