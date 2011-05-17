using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ISIS.Web.Areas.Schedule.Models;
using ISIS.Web.Areas.Schedule.Models.Instructor;

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
        private Index GetInstructorsList()
        {
            return new Index(
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
        public ActionResult Details(Guid Id)
        {
            return Request.IsAjaxRequest()
                       ? (ActionResult) Json(GetDetails(Id), JsonRequestBehavior.AllowGet)
                       : View(GetDetails(Id));
        }

        [NonAction]
        private Details GetDetails(Guid Id)
        {
            var instructors = GetInstructorsList().Instructors;
            return new Details(
                instructors,
                Guid.NewGuid(),
                "John", "Smith",
                new HashSet<String>(new[]
                                        {
                                            "MATH 1301 - College Algebra",
                                            "MATH 2301 - Calculus 1"
                                        }));
        }

    }

}
