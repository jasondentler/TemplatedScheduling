using System;

namespace ISIS.Scheduling
{

    public class InstructorUnassignedFromTemplate 
    {
        public Guid InstructorId { get; private set; }
        public Guid TemplateId { get; private set; }
        public string Label { get; private set; }

        public InstructorUnassignedFromTemplate(
            Guid instructorId,
            Guid templateId,
            string label)
        {
            InstructorId = instructorId;
            TemplateId = templateId;
            Label = label;
        }
    }

}
