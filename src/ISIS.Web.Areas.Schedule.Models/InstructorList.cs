using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models
{
    public class InstructorList
    {
        public IEnumerable<InstructorListItem> Items { get; private set; }

        public InstructorList(IEnumerable<InstructorListItem> items)
        {
            Items = items;
        }
    }
}
