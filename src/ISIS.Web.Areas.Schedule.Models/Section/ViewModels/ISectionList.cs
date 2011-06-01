using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{

    public interface ISectionList
    {

        IEnumerable<SectionListItem> Sections { get; }
        string CourseName { get; }

    }

}
