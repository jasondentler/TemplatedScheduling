using System;

namespace ISIS.Scheduling
{
    public class InstructorEquipmentRemovedFromCourse
    {
        public Guid CourseId { get; private set; }
        public int QuantityRemoved { get; private set; }
        public string EquipmentName { get; private set; }
        public int TotalRequired { get; private set; }

        public InstructorEquipmentRemovedFromCourse(
            Guid courseId, 
            int quantityRemoved,
            string equipmentName,
            int totalRequired)
        {
            CourseId = courseId;
            QuantityRemoved = quantityRemoved;
            EquipmentName = equipmentName;
            TotalRequired = totalRequired;
        }
    }
}
