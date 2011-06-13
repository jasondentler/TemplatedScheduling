using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Building : TreeItem
    {
        public Building(
            Guid id, string text, string detailsLinkUrl, 
            bool hasChildren, string loadChildrenUrl)
            : base(id, text, detailsLinkUrl, hasChildren, loadChildrenUrl)
        {
        }

        public Building(
            Guid id, string text, string detailsLinkUrl, 
            IEnumerable<Map> children)
            : base(id, text, detailsLinkUrl, children)
        {
        }

        public override string Type
        {
            get { return "building"; }
        }

    }
}
