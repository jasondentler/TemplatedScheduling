using System;

namespace ISIS.Scheduling
{
    public class StudentEquipmentRemovedFromCourse
    {
        public Guid CourseId { get; private set; }
        public int QuantityRemoved { get; private set; }
        public string EquipmentName { get; private set; }
        public int PerStudent { get; private set; }

        public StudentEquipmentRemovedFromCourse(
            Guid courseId, 
            int quantityRemoved,
            string equipmentName,
            int perStudent)
        {
            CourseId = courseId;
            QuantityRemoved = quantityRemoved;
            EquipmentName = equipmentName;
            PerStudent = perStudent;
        }
    }
}
