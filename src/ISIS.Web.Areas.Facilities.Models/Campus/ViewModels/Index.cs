using System;
using System.Collections.Generic;
using ISIS.Web.Areas.Facilities.Models.Tree;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Facilities.Models.Campus.ViewModels
{
    public class Index : JsonSerializable, IMapList 
    {
        public IEnumerable<ITreeItem> RootItems { get; private set; }
        public Guid SelectedItem { get; private set; }

        public Index(IEnumerable<ITreeItem> rootItems)
        {
            RootItems = rootItems;
            SelectedItem = Guid.Empty;
        }
    }
}
