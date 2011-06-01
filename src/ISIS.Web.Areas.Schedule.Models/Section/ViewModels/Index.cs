using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{
    public class Index : JsonSerializable, ISectionList
    {
        public IEnumerable<SectionListItem> Sections { get; private set; }

        public string CourseName { get; protected set; }

        public Index(IEnumerable<SectionListItem> sections)
        {
            Sections = sections;
        }

    }
}
