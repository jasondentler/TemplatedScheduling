using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Room : TreeItem
    {
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
    }
}
