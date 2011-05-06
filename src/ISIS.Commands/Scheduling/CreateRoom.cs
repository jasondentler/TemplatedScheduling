using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class CreateRoom : CommandBase 
    {

        public Guid RoomId { get; private set; }
        public string RoomNumber { get; private set; }

        public CreateRoom(Guid roomId, string roomNumber)
        {
            RoomId = roomId;
            RoomNumber = roomNumber;
        }
    }
}
