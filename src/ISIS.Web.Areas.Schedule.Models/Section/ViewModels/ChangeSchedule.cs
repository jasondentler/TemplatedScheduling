using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{
    public class ChangeSchedule : Index 
    {
        public Guid Id { get; set; }
        public string SectionName { get; set; }

        public ChangeSchedule(
            IEnumerable<SectionListItem> sections,
            Guid id,
            string courseName,
            string sectionName) 
            : base(sections)
        {
            Id = id;
            CourseName = courseName;
            SectionName = sectionName;
        }
    }
}
