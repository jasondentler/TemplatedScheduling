using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Map.ViewModels
{
    public class Building : ITreeItem
    {
        public Guid Id { get; private set; }

        public string Text { get; set; }

        public string Type
        {
            get { return "building"; }
        }

        public IEnumerable<ITreeItem> Children { get; private set; }

        public Building(string text,
                        IEnumerable<Map> maps)
        {
            Id = Guid.NewGuid();
            Text = text;
            Children = maps;
        }

    }
}
