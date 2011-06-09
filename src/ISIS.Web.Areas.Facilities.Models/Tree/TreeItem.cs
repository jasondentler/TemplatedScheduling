using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public abstract class TreeItem : ITreeItem
    {
        public Guid Id { get; private set; }

        public string Text { get; set; }

        public bool HasChildren { get; private set; }

        public abstract string Type { get; }

        public abstract string LoadChildrenUrl { get; protected set; }

        protected TreeItem(
            Guid id,
            string text,
            bool hasChildren)
        {
            Id = id;
            Text = text;
            HasChildren = hasChildren;
        }

    }
}
