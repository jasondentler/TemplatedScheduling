using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Building : TreeItem
    {

        public static string DetailsLinkFormat { get; set; }

        public Building(Guid id, string text, bool hasChildren,
            string loadChildrenUrl) 
            : base(id, text, hasChildren)
        {
            LoadChildrenUrl = loadChildrenUrl;
        }

        public Building(Guid id, string text, IEnumerable<Map> maps)
            : base(id, text, maps)
        {
        }

        public override string Type
        {
            get { return "building"; }
        }

        public override string LoadChildrenUrl { get; protected set; }

        public override string DetailsLinkUrl
        {
            get { return string.Format(DetailsLinkFormat, Id); }
        }
    }
}
