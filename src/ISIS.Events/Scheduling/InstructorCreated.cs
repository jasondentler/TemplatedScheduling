using System;

namespace ISIS.Scheduling
{

    public class InstructorCreated 
    {
        public Guid InstructorId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public InstructorCreated(Guid instructorId, string firstName, string lastName)
        {
            InstructorId = instructorId;
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
