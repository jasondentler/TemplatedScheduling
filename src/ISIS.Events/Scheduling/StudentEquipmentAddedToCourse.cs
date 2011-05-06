using System;

namespace ISIS.Scheduling
{
    public class StudentEquipmentAddedToCourse
    {
        public Guid CourseId { get; private set; }
        public int QuantityAdded { get; private set; }
        public string EquipmentName { get; private set; }
        public int PerStudent { get; private set; }

        public StudentEquipmentAddedToCourse(
            Guid courseId, 
            int quantityAdded,
            string equipmentName,
            int perStudent)
        {
            CourseId = courseId;
            QuantityAdded = quantityAdded;
            EquipmentName = equipmentName;
            PerStudent = perStudent;
        }
    }
}
