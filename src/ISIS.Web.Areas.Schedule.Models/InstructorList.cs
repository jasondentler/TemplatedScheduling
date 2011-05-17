using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Schedule.Models
{
    public class InstructorList : JsonSerializable 
    {
        public IEnumerable<InstructorListItem> Instructors { get; private set; }

        public InstructorList(IEnumerable<InstructorListItem> instructors)
        {
            Instructors = instructors;
        }

    }
}
