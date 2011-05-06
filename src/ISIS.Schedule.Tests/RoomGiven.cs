using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class RoomGiven
    {

        [Given(@"I have created the room ([^\s]+)")]
        public void GivenIHaveCreatedTheRoom(
            string roomNumber)
        {
            var roomId = DomainHelper.Id<Room>(roomNumber);
            var @event = new RoomCreated(roomId, roomNumber);
            DomainHelper.Given<Room>(roomId, @event);
        }

        [Given(@"I have created a room")]
        public void GivenIHaveCreatedARoom()
        {
            GivenIHaveCreatedTheRoom("A-123");
        }

        [Given(@"I have added (\d+) (.+) to the room for a total of (\d+)")]
        public void GivenIHaveAddedEquipmentToTheRoom(
            string quantityString,
            string equipmentName,
            string totalString)
        {
            var quanity = int.Parse(quantityString);
            var total = int.Parse(totalString);
            var roomId = DomainHelper.Id<Room>();

            var @event = new EquipmentAddedToRoom(roomId, quanity, equipmentName, total);
            DomainHelper.Given<Room>(@event);
        }

    }
}
