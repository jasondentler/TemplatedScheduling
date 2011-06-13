using System;
using System.Collections.Generic;
using ISIS.Web.Areas.Facilities.Models.Tree;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Facilities.Models.Building.ViewModels
{
    public class Details : JsonSerializable, IMapList 
    {
        public Guid Id { get; set; }
        public Guid CampusId { get; set; }
        public string CampusName { get; set; }
        public string BuildingName { get; set; }
        public IEnumerable<ITreeItem> RootItems { get; private set; }
        public Guid SelectedItem { get; private set; }

        public Details(IMapList tree,
            Guid id,
            string buildingName,
            Guid campusId,
            string campusName)
        {
            Id = id;
            BuildingName = buildingName;
            CampusId = campusId;
            CampusName = campusName;
            RootItems = tree.RootItems;
            SelectedItem = tree.SelectedItem;
        }
    }
}
