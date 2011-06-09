using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Tree;

namespace ISIS.Web.Areas.Facilities.Controllers
{
    public class BuildingController : ControllerBase 
    {

        [HttpGet]
        public JsonResult Data(Guid campusId)
        {
            return Json(GetBuildings(campusId), JsonRequestBehavior.AllowGet);
        }


        [NonAction]
        public IEnumerable<Building> GetBuildings(Guid campusId)
        {
            return FacilitiesSingleton.Facilities.GetChildren(Guid.Empty)
                .Select(tuple => new Building(
                                     tuple.Item1,
                                     tuple.Item2,
                                     tuple.Item3,
                                     Url.Action("Data", "Map", new {buildingId = tuple.Item1})));
        }

    }
}
