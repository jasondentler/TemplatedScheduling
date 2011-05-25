using System;

namespace ISIS.Web.Areas.Schedule.Models.Template.InputModels
{
    public class CreateSection
    {

        public Guid TemplateId { get; set; }
        public Guid SectionId { get; set; }
        public string SectionNumber { get; set; }

    }
}
