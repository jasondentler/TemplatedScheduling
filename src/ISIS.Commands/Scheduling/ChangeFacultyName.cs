using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{

    public class ChangeFacultyName : CommandBase 
    {
        public Guid FacultyId { get; private set; }
        public string NewFirstName { get; private set; }
        public string NewLastName { get; private set; }

        public ChangeFacultyName(Guid facultyId, string newFirstName, string newLastName)
        {
            FacultyId = facultyId;
            NewFirstName = newFirstName;
            NewLastName = newLastName;
        }
    }

}
