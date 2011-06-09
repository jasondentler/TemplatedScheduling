using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public interface ITreeItem
    {
        Guid Id { get; }
        string Text { get; }
        string Type { get; }
        bool HasChildren { get; }
        string LoadChildrenUrl { get; }

    }
}
