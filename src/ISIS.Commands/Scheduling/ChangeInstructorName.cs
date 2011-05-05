using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{

    public class ChangeInstructorName : CommandBase 
    {
        public Guid InstructorId { get; private set; }
        public string NewFirstName { get; private set; }
        public string NewLastName { get; private set; }

        public ChangeInstructorName(Guid instructorId, string newFirstName, string newLastName)
        {
            InstructorId = instructorId;
            NewFirstName = newFirstName;
            NewLastName = newLastName;
        }
    }

}
