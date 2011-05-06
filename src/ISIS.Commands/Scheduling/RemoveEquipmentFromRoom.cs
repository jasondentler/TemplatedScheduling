using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class RemoveEquipmentFromRoom : CommandBase 
    {
        public Guid RoomId { get; private set; }
        public int Quantity { get; private set; }
        public string EquipmentName { get; private set; }

        public RemoveEquipmentFromRoom(Guid roomId, int quantity, string equipmentName)
        {
            RoomId = roomId;
            Quantity = quantity;
            EquipmentName = equipmentName;
        }
    }
}
