using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class AddEquipmentToRoomValidatorFixture
        : ConventionValidationFixture<AddEquipmentToRoom>
    {
        protected override AddEquipmentToRoom GetValidInstance()
        {
            return new AddEquipmentToRoom(
                Guid.NewGuid(),
                15,
                "Toaster Oven");
        }

        [Then]
        public void RoomIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AddEquipmentToRoom(id, 15, "Toaster Oven"),
                cmd => cmd.RoomId);
        }

        [Then]
        public void QuantityisGreaterThanZero()
        {
            GreaterThan(0, qty => new AddEquipmentToRoom(
                                      Guid.NewGuid(),
                                      qty,
                                      "Toaster Oven"),
                        cmd => cmd.Quantity);
        }

        [Then]
        public void EquipmentNameFollowsEquipmentNameRules()
        {
            FollowsEquipmentNameRules(equipmentName => new AddEquipmentToRoom(
                                                           Guid.NewGuid(),
                                                           15,
                                                           equipmentName),
                                      cmd => cmd.EquipmentName);
        }

    }
}
