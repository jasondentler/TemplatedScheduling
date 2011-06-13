using System;
using System.Collections.Generic;
using ISIS.Web.Areas.Facilities.Models.Tree;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Facilities.Models.Campus.ViewModels
{
    public class Details : JsonSerializable, IMapList 
    {
        public Guid Id { get; set; }
        public string CampusName { get; set; }
        public IEnumerable<ITreeItem> RootItems { get; private set; }
        public Guid SelectedItem { get; private set; }

        public Details(IMapList tree,
            Guid id,
            string campusName)
        {
            Id = id;
            CampusName = campusName;
            RootItems = tree.RootItems;
            SelectedItem = tree.SelectedItem;
        }
    }
}
