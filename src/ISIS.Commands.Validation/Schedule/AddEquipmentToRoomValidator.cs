using System;
using FluentValidation;
using ISIS.Scheduling;

namespace ISIS.Schedule
{
    public class AddEquipmentToRoomValidator : AbstractValidator<AddEquipmentToRoom>
    {

        public AddEquipmentToRoomValidator()
        {
            RuleFor(cmd => cmd.RoomId)
                .NotEqual(default(Guid));

            RuleFor(cmd => cmd.Quantity)
                .GreaterThan(0);

            RuleFor(cmd => cmd.EquipmentName)
                .NotEmpty();
        }

    }
}
