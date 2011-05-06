using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class RemoveCourseInstructorEquipment : CommandBase 
    {
        public Guid CourseId { get; private set; }
        public int Quantity { get; private set; }
        public string EquipmentName { get; private set; }

        public RemoveCourseInstructorEquipment(Guid courseId, int quantity, string equipmentName)
        {
            CourseId = courseId;
            Quantity = quantity;
            EquipmentName = equipmentName;
        }
    }
}
