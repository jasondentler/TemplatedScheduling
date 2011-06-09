using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Building : TreeItem
    {
        public Building(Guid id, string text, bool hasChildren,
            string loadChildrenUrl) 
            : base(id, text, hasChildren)
        {
            LoadChildrenUrl = loadChildrenUrl;
        }

        public override string Type
        {
            get { return "building"; }
        }

        public override string LoadChildrenUrl { get; protected set; }
    }
}
