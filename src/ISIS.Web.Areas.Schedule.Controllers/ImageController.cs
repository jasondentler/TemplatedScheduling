using System.Web.Mvc;

namespace ISIS.Web.Areas.Schedule.Controllers
{
    public class ImageController : ControllerBase
    {

        public ActionResult Room(string Id)
        {
            var roomFileName = Id;
            var physicalPath = HttpContext.Server.MapPath("~/Content/images/buildings/" + roomFileName + ".svg");
            var data = System.IO.File.ReadAllBytes(physicalPath);
            return File(data, "image/svg+xml");
        }

    }
}
