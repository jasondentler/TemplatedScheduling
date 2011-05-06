using ISIS.Scheduling;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class RoomThen
    {

        [Then(@"the room ([^\s]+) is created")]
        public void ThenTheRoomIsCreated(
            string roomNumber)
        {
            var roomId = DomainHelper.Id<Room>();

            var e = DomainHelper.Then<RoomCreated>();
            e.RoomId.Should().Be.EqualTo(roomId);
            e.RoomNumber.Should().Be.EqualTo(roomNumber);
        }

        [Then(@"(\d+) (.+) are added to the room for a total of (\d+)")]
        public void ThenEquipmentAddedToTheRoom(
            string quantityAddedString,
            string equipmentName,
            string totalString)
        {
            var quantityAdded = int.Parse(quantityAddedString);
            var total = int.Parse(totalString);
            var roomId = DomainHelper.Id<Room>();

            var e = DomainHelper.Then<EquipmentAddedToRoom>();
            e.RoomId.Should().Be.EqualTo(roomId);
            e.QuanityAdded.Should().Be.EqualTo(quantityAdded);
            e.NewTotal.Should().Be.EqualTo(total);
        }

        [Then(@"(\d+) (.+) are removed from the room for a total of (\d+)")]
        public void ThenEquipmentRemovedFromTheRoom(
            string quantityRemovedString,
            string equipmentName,
            string totalString)
        {
            var quantityRemoved = int.Parse(quantityRemovedString);
            var total = int.Parse(totalString);
            var roomId = DomainHelper.Id<Room>();

            var e = DomainHelper.Then<EquipmentRemovedFromRoom>();
            e.RoomId.Should().Be.EqualTo(roomId);
            e.QuanityRemoved.Should().Be.EqualTo(quantityRemoved);
            e.NewTotal.Should().Be.EqualTo(total);
        }


    }
}
