using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ISIS.Web.Areas.Schedule.Models.Instructor;
using Microsoft.Web.Mvc;

namespace ISIS.Web.Areas.Schedule.Controllers
{

    public class InstructorController : ControllerBase 
    {

        [HttpGet]
        public ActionResult Index()
        {
            return Request.IsAjaxRequest()
                       ? (ActionResult) Json(GetInstructorsList(), JsonRequestBehavior.AllowGet)
                       : View(GetInstructorsList());
        }

        [HttpGet]
        public ActionResult Details(Guid Id)
        {
            if (Request.IsAjaxRequest())
            {
                return Json(GetDetails(Id), JsonRequestBehavior.AllowGet);
            }
            return View(GetDetails(Id));
        }

        [HttpPost]
        public RedirectToRouteResult Create(Create model)
        {
            return ModelState.IsValid
                       ? this.RedirectToAction(c => c.Details(model.Id))
                       : this.RedirectToAction(c => c.Index());
        }

        [HttpPost]
        public RedirectToRouteResult Rename(Rename model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult AddCourse(AddCourse model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult RemoveCourses(RemoveCourses model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
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

        [NonAction]
        private Details GetDetails(Guid Id)
        {
            var instructors = GetInstructorsList().Instructors;
            return new Details(
                instructors,
                Guid.NewGuid(),
                "John", "Smith",
                new Dictionary<Guid, string>()
                    {
                        {Guid.NewGuid(), "MATH 1301 College Algebra"},
                        {Guid.NewGuid(), "MATH 2301 Calculus 1"}
                    },
                new Dictionary<Guid, string>()
                    {
                        {Guid.NewGuid(), "MATH 0307 DevEd Math 1"},
                        {Guid.NewGuid(), "MATH 0308 DevEd Math 2"},
                        {Guid.NewGuid(), "MATH 0309 DevEd Math 3"},
                        {Guid.NewGuid(), "MATH 1301 College Algebra"},
                        {Guid.NewGuid(), "MATH 2301 Calculus 1"},
                        {Guid.NewGuid(), "MATH 2301 Calculus 2"}
                    });
        }

    }

}
