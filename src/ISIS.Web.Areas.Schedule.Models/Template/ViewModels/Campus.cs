using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Template.ViewModels
{
    public class Campus
    {
        public string Name { get; set; }
        public IEnumerable<Building> Buildings { get; set; }

        public Campus(string name, IEnumerable<Building> buildings)
        {
            Name = name;
            Buildings = buildings;
        }
    }
}
