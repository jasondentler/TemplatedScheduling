using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{

    public class CreateInstructor : CommandBase 
    {
        public Guid InstructorId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public CreateInstructor(Guid instructorId, string firstName, string lastName)
        {
            InstructorId = instructorId;
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
