using System;

namespace ISIS.Web.Areas.Facilities.Models.Room.InputModels
{
    public class AddEquipment
    {

        public Guid RoomId { get; set; }
        public int Quantity { get; set; }
        public string Equipment { get; set; }

    }
}
