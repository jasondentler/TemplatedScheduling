using System;
using System.Collections.Generic;
using ISIS.Web.Areas.Facilities.Models.Tree;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Facilities.Models.Equipment.ViewModels
{
    public class Index : JsonSerializable, IMapList 
    {
        public IEnumerable<ITreeItem> RootItems { get; private set; }
        public IEnumerable<string> Equipment { get; set; }
        public Guid SelectedItem { get { return Guid.Empty; } }

        public Index(
            IEnumerable<ITreeItem> rootItems,
            IEnumerable<string> equipment)
        {
            RootItems = rootItems;
            Equipment = equipment;
        }
    }
}
