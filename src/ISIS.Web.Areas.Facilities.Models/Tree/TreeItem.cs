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

        public string LoadChildrenUrl { get; protected set; }

        public string DetailsLinkUrl { get; protected set; }

        protected TreeItem(
            Guid id,
            string text,
            string detailsLinkUrl,
            bool hasChildren,
            string loadChildrenUrl)
        {
            Id = id;
            Text = text;
            HasChildren = hasChildren;
            LoadChildrenUrl = loadChildrenUrl;
            DetailsLinkUrl = detailsLinkUrl;
            ChildrenLoaded = false;
        }

        protected TreeItem(
            Guid id, 
            string text, 
            string detailsLinkUrl,
            IEnumerable<ITreeItem> children)
        {
            Id = id;
            Text = text;
            DetailsLinkUrl = detailsLinkUrl;
            HasChildren = children.Any();
            Children = children;
            ChildrenLoaded = true;
        }

    }
}
