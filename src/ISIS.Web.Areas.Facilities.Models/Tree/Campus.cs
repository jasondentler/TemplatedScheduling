using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Campus : TreeItem
    {
        public Campus(
            Guid id, string text, string detailsLinkUrl, 
            bool hasChildren, string loadChildrenUrl)
            : base(id, text, detailsLinkUrl, hasChildren, loadChildrenUrl)
        {
        }

        public Campus(
            Guid id, string text, string detailsLinkUrl, 
            IEnumerable<Building> children)
            : base(id, text, detailsLinkUrl, children)
        {
        }

        public override string Type
        {
            get { return "campus"; }
        }

    }
}