using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Campus.ViewModels;
using ISIS.Web.Areas.Facilities.Models.Tree;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class CampusController : ControllerBase 
    {

        [HttpGet]
        public ViewResult Details(Guid Id)
        {
            var tree = new TreeSource().GetTree(Id, Url);
            return View(tree);

        }
        [HttpGet]
        public ViewResult Index()
        {
            //var tree = new TreeSource().GetTree(Guid.Empty, Url);
            return View(new Index(GetCampuses()));
        }

        [HttpGet]
        public JsonResult Data()
        {
                return Json(GetCampuses(), JsonRequestBehavior.AllowGet);
        }


        [NonAction]
        public IEnumerable<Campus> GetCampuses()
        {
            return FacilitiesSingleton.Facilities.GetChildren(Guid.Empty)
                .Select(tuple => new Campus(
                                     tuple.Item1,
                                     tuple.Item2,
                                     Url.Action("Details", new {Id = tuple.Item1}),
                                     tuple.Item3,
                                     Url.Action("Data", "Building", new {campusId = tuple.Item1})));
        }

    }
}
