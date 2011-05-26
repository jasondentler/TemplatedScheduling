using System;

namespace ISIS.Web.Areas.Schedule.Models.Template.InputModels
{
    public class RemoveStudentEquipment
    {

        public Guid TemplateId { get; set; }
        public Guid[] EquipmentIds { get; set; }

    }
}
