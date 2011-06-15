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
            var tree = new TreeSource().GetTree(Guid.Empty, Url);
            return View(new Index(tree.RootItems));
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
            var tree = new TreeSource().GetTree(Guid.Empty, Url);
            return Json(tree.RootItems, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public RedirectToRouteResult AddCampus(AddCampus model)
        {
            var campusId = Guid.NewGuid();
            // For now, so we don't redirect to a non-existent campus
            campusId = FacilitiesSingleton.Facilities.GetChildren(Guid.Empty).First().Item1;
            return this.RedirectToAction(c => c.Details(campusId));
        }

    }
}
