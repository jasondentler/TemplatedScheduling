using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Room : TreeItem
    {

        public Room(Guid id, string text, string detailsUrl) 
            : base(id, text, detailsUrl, new ITreeItem[0])
        {
        }

        public override string Type
        {
            get { return "room"; }
        }

    }
}
