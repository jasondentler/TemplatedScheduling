using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{
    public class AssignInstructorToSection : CommandBase 
    {
        public Guid SectionId { get; private set; }
        public Guid InstructorId { get; private set; }

        public AssignInstructorToSection(
            Guid sectionId,
            Guid instructorId)
        {
            SectionId = sectionId;
            InstructorId = instructorId;
        }
    }
}
