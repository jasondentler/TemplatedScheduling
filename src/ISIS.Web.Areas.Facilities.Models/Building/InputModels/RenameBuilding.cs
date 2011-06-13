using System;

namespace ISIS.Web.Areas.Facilities.Models.Building.InputModels
{
    public class RenameBuilding
    {

        public Guid BuildingId { get; set; }
        public string NewBuildingName { get; set; }

    }
}
