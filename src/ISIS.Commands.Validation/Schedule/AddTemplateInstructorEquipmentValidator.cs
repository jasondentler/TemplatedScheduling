using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class AddTemplateInstructorEquipmentValidator : AbstractValidator<AddTemplateInstructorEquipment>
    {

        public AddTemplateInstructorEquipmentValidator()
        {
            RuleFor(cmd => cmd.TemplateId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.Quantity)
                .GreaterThan(0);

            RuleFor(cmd => cmd.EquipmentName)
                .EquipmentName();
        }

    }
}
