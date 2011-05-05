using System;

namespace ISIS.Scheduling
{

    public class FacultyUnassignedFromTemplate 
    {
        public Guid FacultyId { get; private set; }
        public Guid TemplateId { get; private set; }
        public string Label { get; private set; }

        public FacultyUnassignedFromTemplate(
            Guid facultyId,
            Guid templateId,
            string label)
        {
            FacultyId = facultyId;
            TemplateId = templateId;
            Label = label;
        }
    }

}
