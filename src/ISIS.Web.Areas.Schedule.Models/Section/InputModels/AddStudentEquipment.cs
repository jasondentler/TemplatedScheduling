using System;

namespace ISIS.Web.Areas.Schedule.Models.Section.InputModels
{
    public class AddStudentEquipment
    {

        public Guid SectionId { get; set; }
        public Guid EquipmentId { get; set; }
        public int Quantity { get; set; }
        public int PerStudent { get; set; }
        
    }
}
