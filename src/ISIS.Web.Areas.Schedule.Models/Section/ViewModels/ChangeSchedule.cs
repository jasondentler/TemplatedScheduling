using System;
using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Schedule.Models.Section.ViewModels
{
    public class ChangeSchedule : Index 
    {
        public Guid Id { get; set; }
        public string SectionName { get; set; }
        public StandardScheduleData StandardScheduleData { get; set; }

        public ChangeSchedule(
            IEnumerable<SectionListItem> sections,
            Guid id,
            string courseName,
            string sectionName,
            StandardScheduleData standardScheduleData ) 
            : base(sections)
        {
            Id = id;
            CourseName = courseName;
            SectionName = sectionName;
            StandardScheduleData = standardScheduleData;
        }
    }

    public class StandardScheduleData : JsonSerializable 
    {
        public IEnumerable<string> Days { get; set; }
        public IDictionary<string, IEnumerable<string>> Times { get; set; }

        public StandardScheduleData(
            IEnumerable<string> days,
            IDictionary<string, IEnumerable<string>> times)
        {
            Days = days;
            Times = times;
        }
    }

}
