using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Map.InputModels;
using ISIS.Web.Areas.Facilities.Models.Map.ViewModels;
using ISIS.Web.Areas.Facilities.Models.Tree;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class MapController : ControllerBase 
    {

        [HttpGet]
        public ViewResult Details(Guid Id)
        {
            var tree = new TreeSource().GetTree(Id, Url);

            var mapId = Id;
            var buildingId = FacilitiesSingleton.Facilities.GetParent(mapId);
            var campusId = FacilitiesSingleton.Facilities.GetParent(buildingId);

            var campus = tree.RootItems.Single(item => item.Id == campusId);
            var campusName = campus.Text;

            var building = campus.Children.Single(item => item.Id == buildingId);
            var buildingName = building.Text;

            var map = building.Children.Single(item => item.Id == mapId);
            var mapName = map.Text;

            var model = new Details(tree, mapId, mapName, buildingId, buildingName, campusId, campusName);
            return View(model);
        }

        [HttpGet]
        public JsonResult Data(Guid buildingId)
        {
            return Json(GetMaps(buildingId), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public RedirectToRouteResult AddRoom(AddRoom model)
        {
            var roomId = Guid.NewGuid();
            // For now: Do our best not to redirect to nowhere or yellow-screen-of-death
            roomId = FacilitiesSingleton.Facilities.GetChildren(model.MapId).First().Item1;
            return this.RedirectToAction<RoomController>(c => c.Details(roomId));
        }

        [HttpPost]
        public RedirectToRouteResult RemoveMap(RemoveMap model)
        {
            var buildingId = FacilitiesSingleton.Facilities.GetParent(model.MapId);
            return this.RedirectToAction<BuildingController>(c => c.Details(buildingId));
        }

        [HttpPost]
        public RedirectToRouteResult RenameMap(RenameMap model)
        {
            return this.RedirectToAction(c => c.Details(model.MapId));
        }

        [HttpPost]
        public RedirectToRouteResult UploadMapImage(UploadMapImage model)
        {
            return this.RedirectToAction(c => c.Details(model.MapId));
        }


        [NonAction]
        public IEnumerable<Map> GetMaps(Guid buildingId)
        {
            return FacilitiesSingleton.Facilities.GetChildren(buildingId)
                .Select(tuple => new Map(
                                     tuple.Item1,
                                     tuple.Item2,
                                     Url.Action("Details", new {Id = tuple.Item1}),
                                     tuple.Item3,
                                     Url.Action("Data", "Room", new {mapId = tuple.Item1})));
        }
        
    }
}
