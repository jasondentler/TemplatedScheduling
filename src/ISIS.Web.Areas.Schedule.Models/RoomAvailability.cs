using System;
using ISIS.Web.Areas.Schedule.Models.Template.ViewModels;

namespace ISIS.Web.Areas.Schedule.Models
{
    public class RoomAvailability
    {
        public Guid RoomId { get; set; }
        public string Campus { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public RoomStatuses Status { get; set; }
        public string Message { get; set; }

        public RoomAvailability(
            Guid roomId,
            string campus,
            string building,
            string floor,
            string room,
            RoomStatuses status)
        {
            RoomId = roomId;
            Campus = campus;
            Building = building;
            Floor = floor;
            Room = room;
            Status = status;
        }

        public RoomAvailability(
            Guid roomId,
            string campus,
            string building,
            string floor,
            string room,
            RoomStatuses status,
            string message)
        {
            RoomId = roomId;
            Campus = campus;
            Building = building;
            Floor = floor;
            Room = room;
            Status = status;
            Message = message;
        }


    }
}