using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class AssignInstructorToTemplate : CommandBase 
    {
        public Guid TemplateId { get; private set; }
        public Guid InstructorId { get; private set; }

        public AssignInstructorToTemplate(Guid templateId, Guid instructorId)
        {
            TemplateId = templateId;
            InstructorId = instructorId;
        }
    }
}
