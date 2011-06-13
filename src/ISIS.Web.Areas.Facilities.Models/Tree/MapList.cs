using System;
using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class MapList : JsonSerializable, IMapList
    {
        public IEnumerable<ITreeItem> RootItems { get; private set; }
        public Guid SelectedItem { get; private set; }

        public MapList(IEnumerable<ITreeItem> rootItems, Guid selectedItem)
        {
            RootItems = rootItems;
            SelectedItem = selectedItem;
        }

    }
}
