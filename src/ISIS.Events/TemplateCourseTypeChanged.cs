using System;

namespace ISIS.Events
{
    public class TemplateCourseTypeChanged
    {

        public Guid TemplateId { get; private set; }
        public CourseTypes CourseType { get; private set; }

        public TemplateCourseTypeChanged(Guid templateId, CourseTypes courseType)
        {
            TemplateId = templateId;
            CourseType = courseType;
        }
    }
}
