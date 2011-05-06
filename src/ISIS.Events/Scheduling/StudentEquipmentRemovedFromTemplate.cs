using System;

namespace ISIS.Scheduling
{
    public class StudentEquipmentRemovedFromTemplate
    {
        public Guid TemplateId { get; private set; }
        public int QuantityRemoved { get; private set; }
        public string EquipmentName { get; private set; }
        public int PerStudent { get; private set; }

        public StudentEquipmentRemovedFromTemplate(
            Guid templateId, 
            int quantityRemoved,
            string equipmentName,
            int perStudent)
        {
            TemplateId = templateId;
            QuantityRemoved = quantityRemoved;
            EquipmentName = equipmentName;
            PerStudent = perStudent;
        }
    }
}
