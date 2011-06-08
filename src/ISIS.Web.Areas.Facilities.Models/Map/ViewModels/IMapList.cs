using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Map.ViewModels
{

    public interface IMapList 
    {

        IEnumerable<ITreeItem> RootItems { get; }

    }

}
