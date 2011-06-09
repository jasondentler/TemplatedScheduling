using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{

    public interface IMapList 
    {

        IEnumerable<ITreeItem> RootItems { get; }
        Guid SelectedItem { get; }

    }

}
