using System;

namespace ISIS.Web.Areas.Facilities.Models.Room.InputModels
{
    public class RenameRoom
    {

        public Guid RoomId { get; set; }
        public string NewRoomName { get; set; }

    }
}
