using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Template.ViewModels
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
