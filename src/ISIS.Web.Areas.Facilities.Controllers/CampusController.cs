using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Campus.InputModels;
using ISIS.Web.Areas.Facilities.Models.Campus.ViewModels;
using ISIS.Web.Areas.Facilities.Models.Tree;
using Microsoft.Web.Mvc;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class CampusController : ControllerBase 
    {

        [HttpGet]
        public ViewResult Index()
        {
            return View(new Index(GetCampuses()));
        }

        [HttpGet]
        public ViewResult Details(Guid Id)
        {
            var tree = new TreeSource().GetTree(Id, Url);
            var model = new Details(tree, Id, tree.RootItems.Single(item => item.Id == Id).Text);
            return View(model);
        }

        [HttpGet]
        public JsonResult Data()
        {
                return Json(GetCampuses(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public RedirectToRouteResult AddBuilding(AddBuilding model)
        {
            var buildingId = Guid.NewGuid();
            // For now, so we don't redirect to a non-existent building
            buildingId = FacilitiesSingleton.Facilities.GetChildren(model.CampusId).First().Item1;
            return this.RedirectToAction<BuildingController>(c => c.Details(buildingId));
        }

        [HttpPost]
        public RedirectToRouteResult RemoveCampus(RemoveCampus model)
        {
            return this.RedirectToAction(c => c.Index());
        }

        [HttpPost]
        public RedirectToRouteResult RenameCampus(RenameCampus model)
        {
            return this.RedirectToAction(c => c.Details(model.CampusId));
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
