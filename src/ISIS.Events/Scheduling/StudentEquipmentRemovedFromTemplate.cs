using System;

namespace ISIS.Scheduling
{
    public class StudentEquipmentRemovedFromTemplate
    {
        public Guid TemplateId { get; private set; }
        public string EquipmentName { get; private set; }

        public StudentEquipmentRemovedFromTemplate(
            Guid templateId, 
            string equipmentName)
        {
            TemplateId = templateId;
            EquipmentName = equipmentName;
        }
    }
}
