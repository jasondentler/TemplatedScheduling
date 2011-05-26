using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Template.ViewModels
{
    public class ChangeStudentEquipment : Index 
    {
        public Guid Id { get; set; }
        public string TemplateName { get; set; }
        public IDictionary<Guid, string> EquipmentList { get; set; }
        public IDictionary<Guid, string> RequiredEquipment { get; set; }

        public ChangeStudentEquipment(IEnumerable<TemplateListItem> templates,
            Guid id,
            string courseName,
            string templateName, 
            IDictionary<Guid, string> equipmentList,
            IDictionary<Guid, string> requiredEquipment)
            : base(templates)
        {
            Id = id;
            CourseName = courseName;
            TemplateName = templateName;
            EquipmentList = equipmentList;
            RequiredEquipment = requiredEquipment;
        }
    }
}
