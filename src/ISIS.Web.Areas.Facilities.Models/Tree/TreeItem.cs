using System;
using System.Collections.Generic;
using System.Linq;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public abstract class TreeItem : ITreeItem
    {
        public Guid Id { get; private set; }

        public string Text { get; set; }

        public bool HasChildren { get; private set; }

        public bool ChildrenLoaded { get; private set; }

        public IEnumerable<ITreeItem> Children { get; protected set; }

        public abstract string Type { get; }

        public abstract string LoadChildrenUrl { get; protected set; }

        public abstract string DetailsLinkUrl { get; }

        protected TreeItem(
            Guid id,
            string text,
            bool hasChildren)
        {
            Id = id;
            Text = text;
            HasChildren = hasChildren;
            ChildrenLoaded = false;
        }

        protected TreeItem(Guid id, string text, IEnumerable<ITreeItem> children)
        {
            Id = id;
            Text = text;
            HasChildren = children.Any();
            Children = children;
            ChildrenLoaded = true;
        }

    }
}
