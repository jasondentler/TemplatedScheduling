using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class AddCourseStudentEquipmentValidator : AbstractValidator<AddCourseStudentEquipment>
    {

        public AddCourseStudentEquipmentValidator()
        {
            RuleFor(cmd => cmd.CourseId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.Quantity)
                .GreaterThan(0);

            RuleFor(cmd => cmd.EquipmentName)
                .EquipmentName();

            RuleFor(cmd => cmd.PerStudent)
                .GreaterThan(0);
        }

    }
}
