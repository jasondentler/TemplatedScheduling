using System;

namespace ISIS.Web.Areas.Facilities.Models.Room.InputModels
{
    public class RemoveEquipment
    {

        public Guid RoomId { get; set; }
        public string Equipment { get; set; }

    }
}
