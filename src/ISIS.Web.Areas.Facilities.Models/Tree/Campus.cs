using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class Campus : TreeItem
    {

        public static string DetailsLinkFormat { get; set; }

        public Campus(Guid id, string text, bool hasChildren,
                      string loadChildrenUrl) 
            : base(id, text, hasChildren)
        {
            LoadChildrenUrl = loadChildrenUrl;
        }

        public Campus(Guid id, string text, IEnumerable<Building> buildings)
            : base(id, text, buildings)
        {
        }

        public override string Type
        {
            get { return "campus"; }
        }

        public override string LoadChildrenUrl { get; protected set; }

        public override string DetailsLinkUrl
        {
            get { return string.Format(DetailsLinkFormat, Id); }
        }
    }
}