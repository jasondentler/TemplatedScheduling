using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Room.InputModels;
using ISIS.Web.Areas.Facilities.Models.Room.ViewModels;
using ISIS.Web.Areas.Facilities.Models.Tree;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class RoomController : ControllerBase
    {

        [HttpGet]
        public ViewResult Details(Guid Id)
        {
            var tree = new TreeSource().GetTree(Id, Url);

            var roomId = Id;
            var mapId = FacilitiesSingleton.Facilities.GetParent(roomId);
            var buildingId = FacilitiesSingleton.Facilities.GetParent(mapId);
            var campusId = FacilitiesSingleton.Facilities.GetParent(buildingId);

            var campus = tree.RootItems.Single(item => item.Id == campusId);
            var campusName = campus.Text;

            var building = campus.Children.Single(item => item.Id == buildingId);
            var buildingName = building.Text;

            var map = building.Children.Single(item => item.Id == mapId);
            var mapName = map.Text;

            var room = map.Children.Single(item => item.Id == roomId);
            var roomName = room.Text;

            var mapImageUrl = Url.Action("Image", "Map", new {Id = mapId});

            var roomPolygon = new Polygon(new[]
                                              {
                                                  new[] {30, 30},
                                                  new[] {30, 200},
                                                  new[] {400, 300},
                                                  new[] {200, 30}
                                              });

            var model = new Details(tree, roomId, roomName, mapId, mapName, buildingId, buildingName, campusId,
                                    campusName, mapImageUrl, roomPolygon);
            return View(model);
        }

        [HttpGet]
        public JsonResult Data(Guid mapId)
        {
            return Json(GetRooms(mapId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public RedirectToRouteResult RemoveRoom(RemoveRoom model)
        {
            var mapId = FacilitiesSingleton.Facilities.GetParent(model.RoomId);
            return this.RedirectToAction<MapController>(c => c.Details(mapId));
        }

        [HttpPost]
        public RedirectToRouteResult RenameRoom(RenameRoom model)
        {
            return this.RedirectToAction(c => c.Details(model.RoomId));
        }

        [HttpPost]
        public ActionResult MoveRoom(MoveRoom model)
        {
            // model.Points is an int[][2] in JSON format
            // model.Points[0][0] is the first point's x value
            // model.Points[0][1] is the first point's y value
            // model.Points[1][0] is the second point's x value
            // model.Points[1][1] is the second point's y value
            // model.Points[2][0] is the third point's x value
            // and so on...
            return Content(model.Points, "application/json");
        }

        [NonAction]
        public IEnumerable<Room> GetRooms(Guid mapId)
        {
            return FacilitiesSingleton.Facilities.GetChildren(mapId)
                .Select(tuple => new Room(tuple.Item1, tuple.Item2, Url.Action("Details", new {Id = tuple.Item1})));

        }

    }
}
