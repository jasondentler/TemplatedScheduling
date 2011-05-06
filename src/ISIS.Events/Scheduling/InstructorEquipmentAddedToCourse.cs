using System;

namespace ISIS.Scheduling
{
    public class InstructorEquipmentAddedToCourse
    {
        public Guid CourseId { get; private set; }
        public int QuantityAdded { get; private set; }
        public string EquipmentName { get; private set; }
        public int TotalRequired { get; private set; }

        public InstructorEquipmentAddedToCourse(
            Guid courseId, 
            int quantityAdded,
            string equipmentName,
            int totalRequired)
        {
            CourseId = courseId;
            QuantityAdded = quantityAdded;
            EquipmentName = equipmentName;
            TotalRequired = totalRequired;
        }
    }
}
