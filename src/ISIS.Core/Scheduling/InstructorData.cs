using System;
using System.Collections.Generic;

namespace ISIS.Scheduling
{

    public struct InstructorData
    {

        public Guid InstructorId;
        public string FirstName;
        public string LastName;
        public IEnumerable<Guid> AssignedCourses;

    }

}
