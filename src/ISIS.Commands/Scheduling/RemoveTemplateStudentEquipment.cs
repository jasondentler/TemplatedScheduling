using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class RemoveTemplateStudentEquipment : CommandBase 
    {
        public Guid TemplateId { get; private set; }
        public string EquipmentName { get; private set; }

        public RemoveTemplateStudentEquipment(Guid templateId, string equipmentName)
        {
            TemplateId = templateId;
            EquipmentName = equipmentName;
        }
    }
}
