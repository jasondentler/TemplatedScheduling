using System;

namespace ISIS.Web.Areas.Schedule.Models.Template.InputModels
{
    public class RemoveInstructorEquipment
    {

        public Guid TemplateId { get; set; }
        public Guid[] InstructorEquipmentId { get; set; }

    }
}
