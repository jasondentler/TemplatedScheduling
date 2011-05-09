using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class CopyTemplateValidator : AbstractValidator<CopyTemplate>
    {

        public CopyTemplateValidator()
        {
            RuleFor(cmd => cmd.NewTemplateId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.SourceTemplateId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.NewTemplateLabel)
                .ShortString(
                    "Please provide a template label",
                    "Template labels can't be longer than 255 characters");
        }

    }
}
