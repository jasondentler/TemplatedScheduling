using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Facilities.Models.Map.ViewModels
{
    public class Index : JsonSerializable, IMapList
    {
        public IEnumerable<ITreeItem> RootItems { get; set; }

        public Index(IEnumerable<Campus> children)
        {
            RootItems = children;
        }
    }
}
