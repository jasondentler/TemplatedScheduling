using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Map : TreeItem
    {
        public Map(Guid id, string text, bool hasChildren,
            string loadChildrenUrl) 
            : base(id, text, hasChildren)
        {
            LoadChildrenUrl = loadChildrenUrl;
        }

        public override string Type
        {
            get { return "map"; }
        }

        public override string LoadChildrenUrl { get; protected set; }
    }
}
