using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class AddTemplateStudentEquipmentValidator : AbstractValidator<AddTemplateStudentEquipment>
    {

        public AddTemplateStudentEquipmentValidator()
        {
            RuleFor(cmd => cmd.TemplateId)
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
