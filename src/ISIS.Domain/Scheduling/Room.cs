using System;
using System.Collections.Generic;
using ISIS.Scheduling.RemoveEquipmentFromRoomExceptions;
using Ncqrs.Domain;

namespace ISIS.Scheduling
{
    public class Room : AggregateRootMappedByConvention
    {

        private readonly Dictionary<string, int> _equipment = new Dictionary<string, int>();

        private Room()
        {
        }

        public Room(Guid roomId, string roomNumber)
            : base(roomId)
        {
            var @event = new RoomCreated(EventSourceId, roomNumber);
            ApplyEvent(@event);
        }

        public void AddEquipment(int quantity, string equipmentName)
        {
            var newTotal = GetCurrentQuantity(equipmentName) + quantity;
            var @event = new EquipmentAddedToRoom(EventSourceId, quantity, equipmentName, newTotal);
            ApplyEvent(@event);
        }

        public void RemoveEquipment(int quantity, string equipmentName)
        {
            var currentTotal = GetCurrentQuantity(equipmentName);
            var newTotal = currentTotal - quantity;

            if (newTotal < 0)
                throw new InsufficientQuantityException(quantity, equipmentName);

            var @event = new EquipmentRemovedFromRoom(EventSourceId, quantity, equipmentName, newTotal);
            ApplyEvent(@event);
        }

        protected int GetCurrentQuantity(string equipmentName)
        {
            return !_equipment.ContainsKey(equipmentName) ? 0 : _equipment[equipmentName];
        }

        protected void On(RoomCreated @event)
        {
        }

        protected void On(EquipmentAddedToRoom @event)
        {
            _equipment[@event.EquipmentName] = @event.NewTotal;
        }

        protected void On(EquipmentRemovedFromRoom @event)
        {
            _equipment[@event.EquipmentName] = @event.NewTotal;
        }

    }
}
