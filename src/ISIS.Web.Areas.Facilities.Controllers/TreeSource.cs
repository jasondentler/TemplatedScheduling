using System;
using System.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Tree;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class TreeSource
    {

        public IMapList GetTree(Guid Id, UrlHelper Url)
        {

            var equipmentUrlProvider = new UrlProvider
                                           {
                                               GetChildrenUrl = id => null,
                                               GetDetailsUrl = id => Url.Action("Index", "Equipment")
                                           };

            var roomTypesUrlProvider = new UrlProvider
                                           {
                                               GetChildrenUrl = id => null,
                                               GetDetailsUrl = id => Url.Action("Index", "Room")
                                           };

            var campusUrlProvider = new UrlProvider
            {
                GetChildrenUrl = id => Url.Action("Data", "Building", new { campusId = id }),
                GetDetailsUrl = id => Url.Action("Details", "Campus", new { Id = id })
            };

            var buildingUrlProvider = new UrlProvider
            {
                GetChildrenUrl = id => Url.Action("Data", "Map", new { buildingId = id }),
                GetDetailsUrl = id => Url.Action("Details", "Building", new { Id = id })
            };

            var mapUrlProvider = new UrlProvider
            {
                GetChildrenUrl = id => Url.Action("Data", "Room", new { mapId = id }),
                GetDetailsUrl = id => Url.Action("Details", "Map", new { Id = id })
            };

            var roomUrlProvider = new UrlProvider
            {
                GetChildrenUrl = id => null,
                GetDetailsUrl = id => Url.Action("Details", "Room", new { Id = id })
            };

            var tree = FacilitiesSource.GetTree(Id, roomUrlProvider, mapUrlProvider, buildingUrlProvider,
                                                campusUrlProvider, equipmentUrlProvider, roomTypesUrlProvider);
            return tree;
        }

    }
}
