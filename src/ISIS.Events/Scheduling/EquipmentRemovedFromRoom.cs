using System;

namespace ISIS.Scheduling
{
    public class EquipmentRemovedFromRoom
    {

        public Guid RoomId { get; private set; }
        public int QuanityRemoved { get; private set; }
        public string EquipmentName { get; private set; }
        public int NewTotal { get; private set; }

        public EquipmentRemovedFromRoom(Guid roomId, int quantityRemoved, string equipmentName, int newTotal)
        {
            RoomId = roomId;
            QuanityRemoved = quantityRemoved;
            EquipmentName = equipmentName;
            NewTotal = newTotal;
        }
    }
}
