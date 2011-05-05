using System;
using System.Collections.Generic;

namespace ISIS.Scheduling
{

    public struct FacultyData
    {

        public Guid FacultyId;
        public string FirstName;
        public string LastName;
        public IEnumerable<Guid> AssignedCourses;

    }

}
