using System;

namespace ISIS.Scheduling
{

    public class FacultyCreated 
    {
        public Guid FacultyId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public FacultyCreated(Guid facultyId, string firstName, string lastName)
        {
            FacultyId = facultyId;
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
