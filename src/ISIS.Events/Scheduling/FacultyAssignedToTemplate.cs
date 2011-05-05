using System;

namespace ISIS.Scheduling
{

    public class FacultyAssignedToTemplate 
    {
        public Guid FacultyId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Guid TemplateId { get; private set; }
        public string Label { get; private set; }

        public FacultyAssignedToTemplate(
            Guid facultyId,
            string firstName,
            string lastName,
            Guid templateId,
            string label)
        {
            FacultyId = facultyId;
            FirstName = firstName;
            LastName = lastName;
            TemplateId = templateId;
            Label = label;
        }
    }

}
