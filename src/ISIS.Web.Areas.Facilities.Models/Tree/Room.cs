using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Room : TreeItem
    {

        public static string DetailsLinkFormat { get; set; }

        public Room(Guid id, string text) 
            : base(id, text, false)
        {
            LoadChildrenUrl = string.Empty;
        }

        public override string Type
        {
            get { return "room"; }
        }

        public override string LoadChildrenUrl { get; protected set; }

        public override string DetailsLinkUrl
        {
            get { return string.Format(DetailsLinkFormat, Id); }
        }
    }
}
