using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Schedule.Models.Instructor
{
    public class Index : JsonSerializable, IInstructorList
    {
        public IEnumerable<InstructorListItem> Instructors { get; private set; }

        public Index(IEnumerable<InstructorListItem> instructors)
        {
            Instructors = instructors;
        }

    }
}
