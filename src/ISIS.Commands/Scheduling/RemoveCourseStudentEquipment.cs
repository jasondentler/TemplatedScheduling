using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class RemoveCourseStudentEquipment : CommandBase 
    {
        public Guid CourseId { get; private set; }
        public string EquipmentName { get; private set; }

        public RemoveCourseStudentEquipment(Guid courseId, string equipmentName)
        {
            CourseId = courseId;
            EquipmentName = equipmentName;
        }
    }
}
