using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{

    public class CreateTemplate : CommandBase 
    {

        public Guid TemplateId { get; private set; }
        public string Label { get; private set; }
        public Guid CourseId { get; private set; }

        public CreateTemplate(Guid templateId, string label, Guid courseId)
        {
            TemplateId = templateId;
            Label = label;
            CourseId = courseId;
        }

    }
}
