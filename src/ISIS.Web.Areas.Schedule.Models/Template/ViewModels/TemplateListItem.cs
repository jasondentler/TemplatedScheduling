using System;

namespace ISIS.Web.Areas.Schedule.Models.Template.ViewModels
{
    public class TemplateListItem
    {

        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string TemplateName { get; set; }

        public TemplateListItem(Guid id, string courseName, string templateName)
        {
            Id = id;
            CourseName = courseName;
            TemplateName = templateName;
        }
    }
}
