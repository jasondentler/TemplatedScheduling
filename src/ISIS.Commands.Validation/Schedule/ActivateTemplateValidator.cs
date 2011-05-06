using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class ActivateTemplateValidator : AbstractValidator<ActivateTemplate>
    {

        public ActivateTemplateValidator()
        {
            RuleFor(cmd => cmd.TemplateId)
                .NotEqual(default(Guid))
                .WithMessage("Provide a template Id.");
        }

    }
}
