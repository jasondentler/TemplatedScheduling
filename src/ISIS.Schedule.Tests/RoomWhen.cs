using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class RoomWhen
    {

        [When(@"I create the room ([^\s]+)")]
        public void WhenICreateTheRoom(
            string roomNumber)
        {
            var roomId = DomainHelper.Id<Room>(roomNumber);
            var cmd = new CreateRoom(roomId, roomNumber);
            DomainHelper.When(cmd);
        }

        [When(@"I add (\d+) (.+) to the room")]
        public void WhenIAddEquipmentToTheRoom(
            string quantityString,
            string equipmentName)
        {
            var roomId = DomainHelper.Id<Room>();
            var quantity = int.Parse(quantityString);

            var cmd = new AddEquipmentToRoom(roomId, quantity, equipmentName);
            DomainHelper.When(cmd);
        }

        [When(@"I remove (\d+) (.+) from the room")]
        public void WhenIRemoveEquipmentFromTheRoom(
            string quantityString,
            string equipmentName)
        {
            var roomId = DomainHelper.Id<Room>();
            var quantity = int.Parse(quantityString);

            var cmd = new RemoveEquipmentFromRoom(roomId, quantity, equipmentName);
            DomainHelper.When(cmd);
        }



    }
}
