using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Map.ViewModels
{
    public interface ITreeItem
    {
        Guid Id { get; }
        string Text { get; }
        string Type { get; }
        IEnumerable<ITreeItem> Children { get; }

    }
}
