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
