using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Map.ViewModels
{
    public class Map  : ITreeItem
    {
        public Guid Id { get; private set; }

        public string Text { get; private set; }

        public string Type { get { return "map"; } }

        public IEnumerable<ITreeItem> Children { get { return new ITreeItem[0]; } }

        public Map(string text)
        {
            Id = Guid.NewGuid();
            Text = text;
        }
    }
}
