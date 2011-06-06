using System;

namespace ISIS.Web.Areas.Schedule.Models.Section.InputModels
{
    public class RemoveStudentEquipment
    {

        public Guid SectionId { get; set; }
        public Guid[] EquipmentIds { get; set; }

    }
}
