using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class CreateSection : CommandBase 
    {

        public Guid SectionId { get; private set; }
        public Guid TemplateId { get; private set; }
        public string SectionNumber { get; private set; }

        public CreateSection(Guid sectionId, Guid templateId, string sectionNumber)
        {
            SectionId = sectionId;
            TemplateId = templateId;
            SectionNumber = sectionNumber;
        }

    }
}
