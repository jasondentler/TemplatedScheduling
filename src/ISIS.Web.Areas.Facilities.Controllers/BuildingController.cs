using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Building.ViewModels;
using Microsoft.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Building.InputModels;
using ISIS.Web.Areas.Facilities.Models.Tree;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class BuildingController : ControllerBase 
    {

        [HttpGet]
        public ViewResult Details(Guid Id)
        {
            var tree = new TreeSource().GetTree(Id, Url);

            var buildingId = Id;
            var campusId = FacilitiesSingleton.Facilities.GetParent(Id);
            var campus = tree.RootItems.Single(item => item.Id == campusId);
            var campusName = campus.Text;

            var building = campus.Children.Single(item => item.Id == buildingId);
            var buildingName = building.Text;

            var model = new Details(tree, buildingId, buildingName, campusId, campusName);
            return View(model);
        }

        [HttpGet]
        public JsonResult Data(Guid campusId)
        {
            return Json(GetBuildings(campusId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public RedirectToRouteResult AddMap(AddMap model)
        {
            var mapId = Guid.NewGuid();
            // For now: Do our best not to redirect to nowhere or yellow-screen-of-death
            mapId = FacilitiesSingleton.Facilities.GetChildren(model.BuildingId).First().Item1;
            return this.RedirectToAction<MapController>(c => c.Details(mapId));
        }

        [HttpPost]
        public RedirectToRouteResult RemoveBuilding(RemoveBuilding model)
        {
            var campusId = FacilitiesSingleton.Facilities.GetParent(model.BuildingId);
            return this.RedirectToAction<CampusController>(c => c.Details(campusId));
        }

        [HttpPost]
        public RedirectToRouteResult RenameBuilding(RenameBuilding model)
        {
            return this.RedirectToAction(c => c.Details(model.BuildingId));
        }



        [NonAction]
        public IEnumerable<Building> GetBuildings(Guid campusId)
        {
            return FacilitiesSingleton.Facilities.GetChildren(campusId)
                .Select(tuple => new Building(
                                     tuple.Item1,
                                     tuple.Item2,
                                     Url.Action("Details", new {Id = tuple.Item1}),
                                     tuple.Item3,
                                     Url.Action("Data", "Map", new {buildingId = tuple.Item1})));
        }

    }
}
