using System;

namespace ISIS.Scheduling
{

    public class RoomCreated
    {
        public Guid RoomId { get; private set; }
        public string RoomNumber { get; private set; }

        public RoomCreated(Guid roomId, string roomNumber)
        {
            RoomId = roomId;
            RoomNumber = roomNumber;
        }
    }

}
