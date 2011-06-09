using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Tree;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class RoomController : ControllerBase
    {

        [HttpGet]
        public JsonResult Data(Guid mapId)
        {
            return Json(GetRooms(mapId), JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public IEnumerable<Room> GetRooms(Guid mapId)
        {
            return FacilitiesSingleton.Facilities.GetChildren(mapId)
                .Select(tuple => new Room(tuple.Item1, tuple.Item2));

        }

    }
}
