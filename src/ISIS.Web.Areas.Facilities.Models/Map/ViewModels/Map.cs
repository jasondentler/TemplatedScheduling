using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Map.ViewModels
{
    public class Map  : ITreeItem
    {
        public string Text { get; private set; }

        public string Type { get { return "map"; } }

        public IEnumerable<ITreeItem> Children { get { return new ITreeItem[0]; } }

        public Map(string text)
        {
            Text = text;
        }
    }
}
