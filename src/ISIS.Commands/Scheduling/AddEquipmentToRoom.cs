using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class AddEquipmentToRoom : CommandBase 
    {
        public Guid RoomId { get; private set; }
        public int Quantity { get; private set; }
        public string EquipmentName { get; private set; }

        public AddEquipmentToRoom(Guid roomId, int quantity, string equipmentName)
        {
            RoomId = roomId;
            Quantity = quantity;
            EquipmentName = equipmentName;
        }
    }
}
