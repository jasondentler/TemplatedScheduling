using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using ISIS.Web.Areas.Facilities.Models.Equipment.InputModels;
using ISIS.Web.Areas.Facilities.Models.Equipment.ViewModels;

namespace ISIS.Web.Areas.Facilities.Controllers
{

    public class EquipmentController : Controller
    {

        public ViewResult Index()
        {
            var tree = new TreeSource().GetTree(Guid.Empty, Url);
            var model = new Index(tree.RootItems, GetEquipment());

            return View(model);
        }


        [HttpPost]
        public RedirectToRouteResult AddEquipment(AddEquipment model)
        {
            return this.RedirectToAction(c => c.Index());
        }

        [HttpPost]
        public RedirectToRouteResult RemoveEquipment(RemoveEquipment model)
        {
            return this.RedirectToAction(c => c.Index());
        }

        [NonAction]
        public IEnumerable<string> GetEquipment()
        {
            return new[]
                       {
                           "PC",
                           "Whiteboard",
                           "Projector",
                           "Lab sink"
                       };
        }
    }

}
