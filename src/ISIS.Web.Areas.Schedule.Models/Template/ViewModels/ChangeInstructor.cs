using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Template.ViewModels
{
    public class ChangeInstructor : Index 
    {
        public Guid Id { get; private set; }
        public string TemplateName { get; private set; }
        public IDictionary<Guid, string> QualifiedInstructors { get; private set; }

        public ChangeInstructor(
            IEnumerable<TemplateListItem> templates,
            Guid id,
            string templateName,
            string courseName,
            IDictionary<Guid, string> qualifiedInstructors) 
            : base(templates)
        {
            Id = id;
            TemplateName = templateName;
            CourseName = courseName;
            QualifiedInstructors = qualifiedInstructors;
        }
    }
}
