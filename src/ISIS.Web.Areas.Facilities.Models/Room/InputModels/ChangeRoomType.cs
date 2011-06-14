using System;

namespace ISIS.Web.Areas.Facilities.Models.Room.InputModels
{
    public class ChangeRoomType
    {

        public Guid RoomId { get; set; }
        public string RoomType { get; set; }

    }
}
