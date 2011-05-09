using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class ChangeInstructorNameValidator : AbstractValidator<ChangeInstructorName>
    {

        public ChangeInstructorNameValidator()
        {
            RuleFor(cmd => cmd.InstructorId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.NewFirstName)
                .ShortString(
                    "Please provide a first name",
                    "First name can't be longer than 255 characters.");

            RuleFor(cmd => cmd.NewLastName)
                .ShortString(
                    "Please provide a last name",
                    "Last name can't be longer than 255 characters.");
        }

    }
}
