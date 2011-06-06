using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{
    public class ChangeRoom : Index
    {
        public Guid Id { get; set; }
        public string SectionName { get; set; }
        public IEnumerable<Campus> Campuses { get; set; }

        public ChangeRoom(
            IEnumerable<SectionListItem> sections,
            Guid id,
            string courseName,
            string sectionName,
            IEnumerable<Campus> campuses) 
            : base(sections)
        {
            Id = id;
            SectionName = sectionName;
            Campuses = campuses;
            CourseName = courseName;
        }
    }
}
