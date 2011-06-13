using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public interface ITreeItem
    {
        Guid Id { get; }
        string Text { get; }
        string Type { get; }
        bool HasChildren { get; }
        bool ChildrenLoaded { get; }
        string LoadChildrenUrl { get; }
        string DetailsLinkUrl { get; }
        IEnumerable<ITreeItem> Children { get; }

    }
}
