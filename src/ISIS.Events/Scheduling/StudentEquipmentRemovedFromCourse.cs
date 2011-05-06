using System;

namespace ISIS.Scheduling
{
    public class StudentEquipmentRemovedFromCourse
    {
        public Guid CourseId { get; private set; }
        public string EquipmentName { get; private set; }

        public StudentEquipmentRemovedFromCourse(
            Guid courseId, 
            string equipmentName)
        {
            CourseId = courseId;
            EquipmentName = equipmentName;
        }
    }
}
