using System.Collections.Generic;
using ISIS.Web.Areas.Schedule.Models.Template.ViewModels;

namespace ISIS.Web.Areas.Schedule.Models
{
    public class Building
    {
        public string Name { get; set; }
        public IEnumerable<BuildingMap> BuildingMaps { get; set; }

        public Building(string name, IEnumerable<BuildingMap> buildingMaps)
        {
            Name = name;
            BuildingMaps = buildingMaps;
        }
    }
}
