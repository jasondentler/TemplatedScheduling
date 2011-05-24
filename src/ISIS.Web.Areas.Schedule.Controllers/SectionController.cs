using System;
using System.Web.Mvc;

namespace ISIS.Web.Areas.Schedule.Controllers
{
    public class SectionController : ControllerBase
    {

        [HttpGet]
        public ActionResult Details(Guid Id)
        {
            return Content("Section #" + Id.ToString());
        }

    }
}
