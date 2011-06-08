using System.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Map.ViewModels;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class MapController : ControllerBase 
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
                return Json(GetMapList(), JsonRequestBehavior.AllowGet);
            return View(GetMapList());
        }

        [NonAction]
        public Index GetMapList()
        {
            return new Index(
                new[]
                    {
                        new Campus("Main Campus",
                                   new[]
                                       {
                                           new Building("A",
                                                        new[]
                                                            {
                                                                new Map("1st Floor"),
                                                                new Map("2nd Floor"),
                                                            }
                                               ),
                                           new Building("B",
                                                        new[]
                                                            {
                                                                new Map("1st Floor"),
                                                                new Map("2nd Floor"),
                                                            }
                                               ),
                                           new Building("C",
                                                        new[]
                                                            {
                                                                new Map("1st Floor"),
                                                                new Map("2nd Floor"),
                                                            }
                                               ),
                                           new Building("D",
                                                        new[]
                                                            {
                                                                new Map("1st Floor"),
                                                                new Map("2nd Floor"),
                                                            }
                                               ),
                                           new Building("E",
                                                        new[]
                                                            {
                                                                new Map("1st Floor")
                                                            }
                                               ),
                                           new Building("F",
                                                        new[]
                                                            {
                                                                new Map("1st Floor"),
                                                                new Map("2nd Floor"),
                                                            }
                                               ),
                                           new Building("G",
                                                        new[]
                                                            {
                                                                new Map("1st Floor")
                                                            }
                                               ),
                                           new Building("H",
                                                        new[]
                                                            {
                                                                new Map("1st Floor")
                                                            }
                                               ),
                                           new Building("J",
                                                        new[]
                                                            {
                                                                new Map("1st Floor")
                                                            }
                                               ),
                                           new Building("K",
                                                        new[]
                                                            {
                                                                new Map("1st Floor")
                                                            }
                                               ),
                                           new Building("N",
                                                        new[]
                                                            {
                                                                new Map("1st Floor")
                                                            }
                                               ),
                                           new Building("Nolan Ryan Center",
                                                        new[]
                                                            {
                                                                new Map("1st Floor")
                                                            }
                                               ),
                                           new Building("G",
                                                        new[]
                                                            {
                                                                new Map("1st Floor"),
                                                                new Map("2nd Floor")
                                                            }
                                               )
                                       }
                            ),
                        new Campus("Pearland", new Building[0]),
                    }
                );
        }


    }
}
