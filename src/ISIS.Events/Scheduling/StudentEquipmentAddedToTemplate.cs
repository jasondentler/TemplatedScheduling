using System;

namespace ISIS.Scheduling
{
    public class StudentEquipmentAddedToTemplate
    {
        public Guid TemplateId { get; private set; }
        public int QuantityAdded { get; private set; }
        public string EquipmentName { get; private set; }
        public int PerStudent { get; private set; }

        public StudentEquipmentAddedToTemplate(
            Guid templateId, 
            int quantityAdded,
            string equipmentName,
            int perStudent)
        {
            TemplateId = templateId;
            QuantityAdded = quantityAdded;
            EquipmentName = equipmentName;
            PerStudent = perStudent;
        }
    }
}
