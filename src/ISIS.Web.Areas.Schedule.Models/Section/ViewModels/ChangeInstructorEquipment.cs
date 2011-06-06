using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{
    public class ChangeInstructorEquipment : Index 
    {
        public Guid Id { get; set; }
        public string SectionName { get; set; }
        public IDictionary<Guid, string> EquipmentList { get; set; }
        public IDictionary<Guid, string> RequiredEquipment { get; set; }

        public ChangeInstructorEquipment(IEnumerable<SectionListItem> sections,
            Guid id,
            string courseName,
            string sectionName, 
            IDictionary<Guid, string> equipmentList,
            IDictionary<Guid, string> requiredEquipment)
            : base(sections)
        {
            Id = id;
            CourseName = courseName;
            SectionName = sectionName;
            EquipmentList = equipmentList;
            RequiredEquipment = requiredEquipment;
        }
    }
}
