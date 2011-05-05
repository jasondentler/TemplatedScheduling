using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class UnassignInstructorFromSection : CommandBase 
    {
        public Guid SectionId { get; private set; }

        public UnassignInstructorFromSection(
            Guid sectionId)
        {
            SectionId = sectionId;
        }
    }
}
