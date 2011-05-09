using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class ChangeCourseDescriptionValidator : AbstractValidator<ChangeCourseDescription>
    {

        public ChangeCourseDescriptionValidator()
        {
            RuleFor(cmd => cmd.CourseId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.Description)
                .NotEmpty()
                .WithMessage("Please provide a description.")
                .Length(0, 1024)
                .WithMessage("Description must be less than 1024 characters");

        }

    }
}
