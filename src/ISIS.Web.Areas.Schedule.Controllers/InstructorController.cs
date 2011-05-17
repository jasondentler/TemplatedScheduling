using System;
using System.Web.Mvc;
using ISIS.Web.Areas.Schedule.Models;

namespace ISIS.Web.Areas.Schedule.Controllers
{

    public class InstructorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Request.IsAjaxRequest()
                       ? (ActionResult) Json(GetInstructorsList(), JsonRequestBehavior.AllowGet)
                       : View(GetInstructorsList());
        }

        [NonAction]
        private InstructorList GetInstructorsList()
        {
            return new InstructorList(
                new[]
                    {
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "John Smith"},
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "Joe Smith"},
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "Jim Smith"},
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "James Smith"},
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "Jane Smith"},
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "Juan Smith"}
                    });
        }

        [HttpGet]
        public ViewResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ViewResult Details(Guid Id)
        {
            throw new NotImplementedException();
        }

    }

}
