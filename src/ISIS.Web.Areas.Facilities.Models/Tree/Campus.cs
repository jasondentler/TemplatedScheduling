using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Campus : TreeItem
    {
        public Campus(Guid id, string text, bool hasChildren,
                      string loadChildrenUrl) 
            : base(id, text, hasChildren)
        {
            LoadChildrenUrl = loadChildrenUrl;
        }

        public override string Type
        {
            get { return "campus"; }
        }

        public override string LoadChildrenUrl { get; protected set; }

    }
}