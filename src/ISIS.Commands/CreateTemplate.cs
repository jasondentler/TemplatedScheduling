using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{

    public class CreateTemplate : CommandBase 
    {

        public Guid TemplateId { get; private set; }
        public Guid CourseId { get; private set; }

        public CreateTemplate(Guid templateId, Guid courseId)
        {
            TemplateId = templateId;
            CourseId = courseId;
        }

    }
}
