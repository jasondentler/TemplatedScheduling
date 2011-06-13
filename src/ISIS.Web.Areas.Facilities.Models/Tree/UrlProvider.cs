using System;

namespace ISIS.Web.Areas.Facilities.Models.Tree
{
    public class UrlProvider
    {
        public Func<Guid, string> GetDetailsUrl { get; set; }
        public Func<Guid, string> GetChildrenUrl { get; set; }
    }
}
