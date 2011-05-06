using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class RemoveTemplateInstructorEquipment : CommandBase 
    {
        public Guid TemplateId { get; private set; }
        public int Quantity { get; private set; }
        public string EquipmentName { get; private set; }

        public RemoveTemplateInstructorEquipment(Guid templateId, int quantity, string equipmentName)
        {
            TemplateId = templateId;
            Quantity = quantity;
            EquipmentName = equipmentName;
        }
    }
}
