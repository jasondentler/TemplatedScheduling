using System;
using System.Collections.Generic;
using System.Linq;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Facilities.Models.Map.ViewModels
{
    public class Index : JsonSerializable, IMapList
    {
        public IEnumerable<ITreeItem> RootItems { get; set; }

        public Guid SelectedItem { get; private set; }

        public Index(IEnumerable<Campus> children)
        {
            RootItems = children;
            SelectedItem = GetItems(children).OrderBy(i => i).First();
        }

        private HashSet<Guid> GetItems(IEnumerable<ITreeItem> items)
        {
            var hs = new HashSet<Guid>();
            foreach (var item in items)
            {
                hs.Add(item.Id);
                foreach (var id in GetItems(item.Children))
                    hs.Add(id);
            }
            return hs;
        }

    }
}
