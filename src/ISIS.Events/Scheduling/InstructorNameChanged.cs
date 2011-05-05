using System;

namespace ISIS.Scheduling
{
    public class InstructorNameChanged
    {
        public Guid InstructorId { get; private set; }
        public string OldFirstName { get; private set; }
        public string OldLastName { get; private set; }
        public string NewFirstName { get; private set; }
        public string NewLastName { get; private set; }

        public InstructorNameChanged(Guid instructorId, string oldFirstName, string oldLastName, string newFirstName, string newLastName)
        {
            InstructorId = instructorId;
            OldFirstName = oldFirstName;
            OldLastName = oldLastName;
            NewFirstName = newFirstName;
            NewLastName = newLastName;
        }

    }
}
