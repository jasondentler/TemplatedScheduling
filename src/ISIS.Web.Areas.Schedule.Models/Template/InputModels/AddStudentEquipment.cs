using System;

namespace ISIS.Web.Areas.Schedule.Models.Template.InputModels
{
    public class AddStudentEquipment
    {

        public Guid TemplateId { get; set; }
        public Guid EquipmentId { get; set; }
        public int Quantity { get; set; }
        public int PerStudent { get; set; }
        
    }
}
