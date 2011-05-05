using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{

    public class CreateFaculty : CommandBase 
    {
        public Guid FacultyId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public CreateFaculty(Guid facultyId, string firstName, string lastName)
        {
            FacultyId = facultyId;
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
