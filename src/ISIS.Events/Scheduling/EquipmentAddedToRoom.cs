using System;

namespace ISIS.Scheduling
{
    public class EquipmentAddedToRoom
    {

        public Guid RoomId { get; private set; }
        public int QuanityAdded { get; private set; }
        public string EquipmentName { get; private set; }
        public int NewTotal { get; private set; }

        public EquipmentAddedToRoom(Guid roomId, int quantityAdded, string equipmentName, int newTotal)
        {
            RoomId = roomId;
            QuanityAdded = quantityAdded;
            EquipmentName = equipmentName;
            NewTotal = newTotal;
        }
    }
}
