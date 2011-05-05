using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class AssignFacultyToTemplate : CommandBase 
    {
        public Guid TemplateId { get; private set; }
        public Guid FacultyId { get; private set; }

        public AssignFacultyToTemplate(Guid templateId, Guid facultyId)
        {
            TemplateId = templateId;
            FacultyId = facultyId;
        }
    }
}
