using System;

namespace ISIS.Scheduling
{

    public class InstructorAssignedToTemplate 
    {
        public Guid InstructorId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Guid TemplateId { get; private set; }
        public string Label { get; private set; }

        public InstructorAssignedToTemplate(
            Guid instructorId,
            string firstName,
            string lastName,
            Guid templateId,
            string label)
        {
            InstructorId = instructorId;
            FirstName = firstName;
            LastName = lastName;
            TemplateId = templateId;
            Label = label;
        }
    }

}
