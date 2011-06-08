using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Map.ViewModels
{
    public class Campus : ITreeItem
    {
        public Guid Id { get; private set; }

        public string Text { get; set; }

        public string Type
        {
            get { return "campus"; }
        }

        public IEnumerable<ITreeItem> Children { get; private set; }

        public Campus(string text,
            IEnumerable<Building> buildings)
        {
            Id = Guid.NewGuid();
            Text = text;
            Children = buildings;
        }
    }
}
