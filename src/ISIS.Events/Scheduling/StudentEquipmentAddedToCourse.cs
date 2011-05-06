using System;

namespace ISIS.Scheduling
{
    public class StudentEquipmentAddedToCourse
    {
        public Guid CourseId { get; private set; }
        public int Quantity { get; private set; }
        public string EquipmentName { get; private set; }
        public int PerStudent { get; private set; }

        public StudentEquipmentAddedToCourse(
            Guid courseId, 
            int quantity,
            string equipmentName,
            int perStudent)
        {
            CourseId = courseId;
            Quantity = quantity;
            EquipmentName = equipmentName;
            PerStudent = perStudent;
        }
    }
}
