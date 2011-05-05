using System;

namespace ISIS.Scheduling
{
    public class FacultyNameChanged
    {
        public Guid FacultyId { get; private set; }
        public string OldFirstName { get; private set; }
        public string OldLastName { get; private set; }
        public string NewFirstName { get; private set; }
        public string NewLastName { get; private set; }

        public FacultyNameChanged(Guid facultyId, string oldFirstName, string oldLastName, string newFirstName, string newLastName)
        {
            FacultyId = facultyId;
            OldFirstName = oldFirstName;
            OldLastName = oldLastName;
            NewFirstName = newFirstName;
            NewLastName = newLastName;
        }

    }
}
