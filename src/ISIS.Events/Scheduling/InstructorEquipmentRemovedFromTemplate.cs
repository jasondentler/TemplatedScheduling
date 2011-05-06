using System;

namespace ISIS.Scheduling
{
    public class InstructorEquipmentRemovedFromTemplate
    {
        public Guid TemplateId { get; private set; }
        public int QuantityRemoved { get; private set; }
        public string EquipmentName { get; private set; }
        public int TotalRequired { get; private set; }

        public InstructorEquipmentRemovedFromTemplate(
            Guid templateId, 
            int quantityRemoved,
            string equipmentName,
            int totalRequired)
        {
            TemplateId = templateId;
            QuantityRemoved = quantityRemoved;
            EquipmentName = equipmentName;
            TotalRequired = totalRequired;
        }
    }
}
