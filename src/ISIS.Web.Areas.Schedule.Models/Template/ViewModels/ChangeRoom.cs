using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Template.ViewModels
{
    public class ChangeRoom : Index 
    {
        public Guid Id { get; set; }
        public string TemplateName { get; set; }
        public IEnumerable<RoomAvailability> Availabilities { get; set; }

        public ChangeRoom(
            IEnumerable<TemplateListItem> templates,
            Guid id,
            string courseName,
            string templateName,
            IEnumerable<RoomAvailability> availabilities) 
            : base(templates)
        {
            Id = id;
            TemplateName = templateName;
            Availabilities = availabilities;
            CourseName = courseName;
        }
    }

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

    public enum RoomStatuses
    {
        Available,
        Unavailable,
        ReducedCapacity,
        MissingEquipment
    }
}
