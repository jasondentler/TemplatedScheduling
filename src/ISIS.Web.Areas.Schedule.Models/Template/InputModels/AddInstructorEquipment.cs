using System;

namespace ISIS.Web.Areas.Schedule.Models.Template.InputModels
{
    public class AddInstructorEquipment
    {

        public Guid TemplateId { get; set; }
        public Guid EquipmentId { get; set; }
        public int Quantity { get; set; }
        
    }
}
