using System;

namespace ISIS.Web.Areas.Facilities.Models.Room.InputModels
{
    public class ChangeCapacity
    {

        public Guid RoomId { get; set; }
        public int Capacity { get; set; }

    }
}
