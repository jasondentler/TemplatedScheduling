using System;

namespace ISIS.Web.Areas.Schedule.Models.Section.InputModels
{
    public class AddInstructorEquipment
    {

        public Guid SectionId { get; set; }
        public Guid EquipmentId { get; set; }
        public int Quantity { get; set; }
        
    }
}
