using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Tree;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class TreeSource
    {

        public IMapList GetTree(Guid Id, UrlHelper Url)
        {
            var campusUrlProvider = new UrlProvider
            {
                GetChildrenUrl = id => Url.Action("Data", "Building", new { campusId = id }),
                GetDetailsUrl = id => Url.Action("Details", "Campus", new { Id = id })
            };

            var buildingUrlProvider = new UrlProvider
            {
                GetChildrenUrl = id => Url.Action("Data", "Map", new { campusId = id }),
                GetDetailsUrl = id => Url.Action("Details", "Building", new { Id = id })
            };

            var mapUrlProvider = new UrlProvider
            {
                GetChildrenUrl = id => Url.Action("Data", "Room", new { campusId = id }),
                GetDetailsUrl = id => Url.Action("Details", "Map", new { Id = id })
            };

            var roomUrlProvider = new UrlProvider
            {
                GetChildrenUrl = id => null,
                GetDetailsUrl = id => Url.Action("Details", "Room", new { Id = id })
            };

            var tree = FacilitiesSource.GetTree(Id, roomUrlProvider, mapUrlProvider, buildingUrlProvider,
                                                campusUrlProvider);
            return tree;
        }

    }
}
