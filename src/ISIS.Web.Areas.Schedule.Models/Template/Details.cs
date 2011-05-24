using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Template
{
    public class Details : Index 
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string TemplateName { get; set; }
        public int Capacity { get; set; }
        public string RoomName { get; set; }
        public string InstructorName { get; set; }
        public IEnumerable<string> InstructorEquipment { get; set; }
        public IEnumerable<string> StudentEquipment { get; set; }
        public bool CanRename { get; set; }
        public bool CanRemove { get; set; }
        public bool CanSetRoom { get; set; }
        public bool CanSetInstructor { get; set; }

        public Details(IEnumerable<TemplateListItem> templates,
            Guid id,
            string courseName,
            string templateName,
            int capacity,
            string roomName,
            string instructorName,
            IEnumerable<string> instructorEquipment,
            IEnumerable<string> studentEquipment,
            bool canRename,
            bool canRemove,
            bool canSetRoom,
            bool canSetInstructor)
            : base(templates)
        {
            Id = id;
            CourseName = courseName;
            TemplateName = templateName;
            Capacity = capacity;
            RoomName = roomName;
            InstructorName = instructorName;
            InstructorEquipment = instructorEquipment;
            StudentEquipment = studentEquipment;
            CanRename = canRename;
            CanRemove = canRemove;
            CanSetRoom = canSetRoom;
            CanSetInstructor = canSetInstructor;
        }
    }
}
