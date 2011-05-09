using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class AddCourseInstructorEquipmentValidator : AbstractValidator<AddCourseInstructorEquipment>
    {

        public AddCourseInstructorEquipmentValidator()
        {
            RuleFor(cmd => cmd.CourseId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.Quantity)
                .GreaterThan(0);

            RuleFor(cmd => cmd.EquipmentName)
                .EquipmentName();
        }

    }
}
