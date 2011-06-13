using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Map : TreeItem
    {

        public static string DetailsLinkFormat { get; set; }

        public Map(Guid id, string text, bool hasChildren,
            string loadChildrenUrl) 
            : base(id, text, hasChildren)
        {
            LoadChildrenUrl = loadChildrenUrl;
        }

        public Map(Guid id, string text, IEnumerable<Room> rooms)
            : base(id, text, rooms)
        {
        }

        public override string Type
        {
            get { return "map"; }
        }

        public override string LoadChildrenUrl { get; protected set; }

        public override string DetailsLinkUrl
        {
            get { return string.Format(DetailsLinkFormat, Id); }
        }
    }
}
