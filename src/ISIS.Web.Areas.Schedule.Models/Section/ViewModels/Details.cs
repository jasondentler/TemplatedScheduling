using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{
    public class Details : Index 
    {
        public Guid Id { get; set; }
        public string SectionName { get; set; }
        public string Term { get; set; }
        public int Capacity { get; set; }
        public string RoomName { get; set; }
        public string InstructorName { get; set; }
        public string ScheduleText { get; set; }
        public IEnumerable<string> InstructorEquipment { get; set; }
        public IEnumerable<string> StudentEquipment { get; set; }

        public Details(
            IEnumerable<SectionListItem> sections,
            Guid id,
            string sectionName,
            string courseName,
            string term,
            int capacity,
            string roomName,
            string instructorName,
            string scheduleText,
            IEnumerable<string> instructorEquipment,
            IEnumerable<string> studentEquipment)
            : base(sections)
        {
            Id = id;
            SectionName = sectionName;
            Term = term;
            Capacity = capacity;
            RoomName = roomName;
            InstructorName = instructorName;
            ScheduleText = scheduleText;
            InstructorEquipment = instructorEquipment;
            StudentEquipment = studentEquipment;
            CourseName = courseName;
        }
    }
}
