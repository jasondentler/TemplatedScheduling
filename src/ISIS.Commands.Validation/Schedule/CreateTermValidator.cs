using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class CreateTermValidator : AbstractValidator<CreateTerm>
    {

        public CreateTermValidator()
        {
            RuleFor(cmd => cmd.TermId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.Abbreviation)
                .Abbreviation(
                    "Please provide a term abbreviation.",
                    "Term abbreviation can't longer than 15 characters.",
                    "No spaces or tabs are allowed in the term abbreviation.",
                    "Term abbreviation can contain only numbers and uppercase letters.");

            RuleFor(cmd => cmd.Name)
                .ShortString(
                    "Please provide a name for this term.",
                    "Term name can't be longer than 255 characters.");

            RuleFor(cmd => cmd.Start)
                .LessThan(cmd => cmd.End)
                .WithMessage("Term start must be before term end");

            RuleFor(cmd => cmd.Start)
                .Must(start => start.TimeOfDay == TimeSpan.Zero)
                .WithMessage("Term start can't include a time");

            RuleFor(cmd => cmd.End)
                .Must(end => end.TimeOfDay == TimeSpan.Zero)
                .WithMessage("Term end can't include a time");

        }

    }
}
