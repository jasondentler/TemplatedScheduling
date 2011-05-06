using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class RemoveCourseStudentEquipment : CommandBase 
    {
        public Guid CourseId { get; private set; }
        public int Quantity { get; private set; }
        public string EquipmentName { get; private set; }
        public int PerStudent { get; private set; }

        public RemoveCourseStudentEquipment(Guid courseId, int quantity, string equipmentName, int perStudent)
        {
            CourseId = courseId;
            Quantity = quantity;
            EquipmentName = equipmentName;
            PerStudent = perStudent;
        }
    }
}
