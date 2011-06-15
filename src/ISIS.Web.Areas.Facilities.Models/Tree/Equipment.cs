using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Equipment : TreeItem
    {
        public Equipment(string detailsLinkUrl) 
            : base(Guid.Empty, "Equipment", detailsLinkUrl, false, string.Empty)
        {
        }

        public override string Type
        {
            get { return "equipment"; }
        }
    }
}
