﻿using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class AddTemplateStudentEquipment : CommandBase 
    {
        public Guid TemplateId { get; private set; }
        public int Quantity { get; private set; }
        public string EquipmentName { get; private set; }
        public int PerStudent { get; private set; }

        public AddTemplateStudentEquipment(Guid templateId, int quantity, string equipmentName, int perStudent)
        {
            TemplateId = templateId;
            Quantity = quantity;
            EquipmentName = equipmentName;
            PerStudent = perStudent;
        }
    }
}