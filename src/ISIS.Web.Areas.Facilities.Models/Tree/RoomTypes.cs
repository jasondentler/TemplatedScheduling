using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class RoomTypes : TreeItem
    {
        public RoomTypes(string detailsLinkUrl) 
            : base(Guid.Empty, "Room Types", detailsLinkUrl, false, string.Empty)
        {
        }

        public override string Type
        {
            get { return "roomTypes"; }
        }
    }
}
