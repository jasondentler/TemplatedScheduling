using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Tree;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class MapController : ControllerBase 
    {

        [HttpGet]
        public ViewResult Details(Guid Id)
        {
            Campus.DetailsLinkFormat = Url.Action("Details", "Campus", new { Id = "asdf" })
                .Replace("asdf", "{0}");
            Building.DetailsLinkFormat = Url.Action("Details", "Building", new { Id = "asdf" })
                .Replace("asdf", "{0}");
            Map.DetailsLinkFormat = Url.Action("Details", "Map", new { Id = "asdf" })
                .Replace("asdf", "{0}");
            Room.DetailsLinkFormat = Url.Action("Details", "Room", new { Id = "asdf" })
                .Replace("asdf", "{0}");

            var campusLoadChildrenUrlFormat = Url.Action("Data", "Building", new { campusId = "asdf" })
                .Replace("asdf", "{0}");
            var buildingLoadChildrenUrlFormat = Url.Action("Data", "Map", new { buildingId = "asdf" })
                .Replace("asdf", "{0}");
            var mapLoadChildrenUrlFormat = Url.Action("Data", "Room", new { mapId = "adsf" })
                .Replace("asdf", "{0}");

            var tree = FacilitiesSource.GetTree(Id,
                                                mapLoadChildrenUrlFormat,
                                                buildingLoadChildrenUrlFormat,
                                                campusLoadChildrenUrlFormat);
            return View(tree);
        }

        [HttpGet]
        public JsonResult Data(Guid buildingId)
        {
            return Json(GetMaps(buildingId), JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public IEnumerable<Map> GetMaps(Guid buildingId)
        {
            return FacilitiesSingleton.Facilities.GetChildren(buildingId)
                .Select(tuple => new Map(
                                     tuple.Item1,
                                     tuple.Item2,
                                     tuple.Item3,
                                     Url.Action("Data", "Room", new {mapId = tuple.Item1})));
        }

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    if (Request.IsAjaxRequest())
        //        return Json(GetMapList(), JsonRequestBehavior.AllowGet);
        //    return View(GetMapList());
        //}

        //[NonAction]
        //public Index GetMapList()
        //{
        //    return new Index(
        //        new[]
        //            {
        //                new TreeItem("Main Campus",
        //                           new[]
        //                               {
        //                                   new Models.Tree.Building("A",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor"),
        //                                                        new Map("2nd Floor"),
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("B",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor"),
        //                                                        new Map("2nd Floor"),
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("C",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor"),
        //                                                        new Map("2nd Floor"),
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("D",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor"),
        //                                                        new Map("2nd Floor"),
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("E",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor")
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("F",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor"),
        //                                                        new Map("2nd Floor"),
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("G",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor")
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("H",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor")
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("J",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor")
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("K",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor")
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("N",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor")
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("Nolan Ryan Center",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor")
        //                                                    }
        //                                       ),
        //                                   new Models.Tree.Building("G",
        //                                                new[]
        //                                                    {
        //                                                        new Map("1st Floor"),
        //                                                        new Map("2nd Floor")
        //                                                    }
        //                                       )
        //                               }
        //                    ),
        //                new TreeItem("Pearland", new Models.Tree.Building[0]),
        //            }
        //        );
        //}


    }
}
