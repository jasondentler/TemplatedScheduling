using System;

namespace ISIS.Scheduling
{
    public class InstructorEquipmentAddedToTemplate
    {
        public Guid TemplateId { get; private set; }
        public int QuantityAdded { get; private set; }
        public string EquipmentName { get; private set; }
        public int TotalRequired { get; private set; }

        public InstructorEquipmentAddedToTemplate(
            Guid templateId, 
            int quantityAdded,
            string equipmentName,
            int totalRequired)
        {
            TemplateId = templateId;
            QuantityAdded = quantityAdded;
            EquipmentName = equipmentName;
            TotalRequired = totalRequired;
        }
    }
}
