using System;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{
    public class SectionListItem
    {

        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string SectionName { get; set; }

        public SectionListItem(Guid id, string courseName, string sectionName)
        {
            Id = id;
            CourseName = courseName;
            SectionName = sectionName;
        }
    }
}
