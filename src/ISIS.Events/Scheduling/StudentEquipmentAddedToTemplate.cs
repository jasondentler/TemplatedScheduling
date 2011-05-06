using System;

namespace ISIS.Scheduling
{
    public class StudentEquipmentAddedToTemplate
    {
        public Guid TemplateId { get; private set; }
        public int Quantity { get; private set; }
        public string EquipmentName { get; private set; }
        public int PerStudent { get; private set; }

        public StudentEquipmentAddedToTemplate(
            Guid templateId, 
            int quantity,
            string equipmentName,
            int perStudent)
        {
            TemplateId = templateId;
            Quantity = quantity;
            EquipmentName = equipmentName;
            PerStudent = perStudent;
        }
    }
}
