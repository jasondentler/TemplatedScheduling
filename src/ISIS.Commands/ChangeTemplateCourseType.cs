using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{
    public class ChangeTemplateCourseType : CommandBase 
    {
        public Guid TemplateId { get; private set; }
        public CourseTypes CourseType { get; private set; }

        public ChangeTemplateCourseType(Guid templateId, CourseTypes courseType)
        {
            TemplateId = templateId;
            CourseType = courseType;
        }
    }
}
