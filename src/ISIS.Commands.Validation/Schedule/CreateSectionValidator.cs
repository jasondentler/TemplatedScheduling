using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class CreateSectionValidator : AbstractValidator<CreateSection>
    {

        public CreateSectionValidator()
        {
            RuleFor(cmd => cmd.SectionId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.TemplateId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.SectionNumber)
                .NotEmpty()
                .WithMessage("Please provide a section number")
                .Matches(@"^[^\s]*$")
                .WithMessage("Section number can't contain spaces or tabs.")
                .Matches(@"^\w*$")
                .WithMessage("Section number can't contain punctuation.")
                .Matches(@"^[^_]*$")
                .WithMessage("Section number can't contain underscores.")
                .Matches(@"^[0-9A-Z]*$")
                .WithMessage("Section number can't contain lowercase characters.");

        }

    }
}
