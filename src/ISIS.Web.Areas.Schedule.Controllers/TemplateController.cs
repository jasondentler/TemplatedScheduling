using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Schedule.Models.Template.InputModels;
using ISIS.Web.Areas.Schedule.Models.Template.ViewModels;
using Microsoft.Web.Mvc;
using ChangeInstructor = ISIS.Web.Areas.Schedule.Models.Template.InputModels.ChangeInstructor;
using ChangeRoom = ISIS.Web.Areas.Schedule.Models.Template.ViewModels.ChangeRoom;

namespace ISIS.Web.Areas.Schedule.Controllers
{
    public class TemplateController : ControllerBase
    {

        [HttpGet]
        public ActionResult Index()
        {
            return Request.IsAjaxRequest()
                       ? (ActionResult) Json(GetTemplateList(), JsonRequestBehavior.AllowGet)
                       : View(GetTemplateList());
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

        [HttpGet]
        public ActionResult ChangeRoom(Guid Id)
        {
            if (Request.IsAjaxRequest())
                return Json(GetChangeRoom(Id), JsonRequestBehavior.AllowGet);
            return View(GetChangeRoom(Id));
        }

        [HttpGet]
        public ActionResult ChangeInstructor(Guid Id)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            if (!Request.IsAjaxRequest())
                return HttpNotFound("Not a JSON request");
            return Json(GetChangeInstructor(Id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ChangeInstructorEquipment(Guid Id)
        {
            if (Request.IsAjaxRequest())
                return Json(GetInstructorEquipment(Id), JsonRequestBehavior.AllowGet);
            return View(GetInstructorEquipment(Id));
        }

        [HttpGet]
        public ActionResult ChangeStudentEquipment(Guid Id)
        {
            if (Request.IsAjaxRequest())
                return Json(GetStudentEquipment(Id), JsonRequestBehavior.AllowGet);
            return View(GetStudentEquipment(Id));
        }

        [HttpPost]
        public RedirectToRouteResult CopyTemplate(Copy model)
        {
            return this.RedirectToAction(c => c.Details(model.CopyId));
        }

        [HttpPost]
        public RedirectToRouteResult CreateSection(CreateSection model)
        {
            return this.RedirectToAction<SectionController>(c => c.Details(model.SectionId));
        }

        [HttpPost]
        public RedirectToRouteResult RemoveTemplate(Remove model)
        {
            return this.RedirectToAction(c => c.Index());
        }

        [HttpPost]
        public RedirectToRouteResult RenameTemplate(Rename model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult ChangeCapacity(ChangeCapacity model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult ChangeInstructor(ChangeInstructor model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult RemoveInstructorEquipment(RemoveInstructorEquipment model)
        {
            return this.RedirectToAction(c => c.ChangeInstructorEquipment(model.TemplateId));
        }

        [HttpPost]
        public RedirectToRouteResult AddInstructorEquipment(AddInstructorEquipment model)
        {
            return this.RedirectToAction(c => c.ChangeInstructorEquipment(model.TemplateId));
        }

        [HttpPost]
        public RedirectToRouteResult RemoveStudentEquipment(RemoveStudentEquipment model)
        {
            return this.RedirectToAction(c => c.ChangeStudentEquipment(model.TemplateId));
        }

        [HttpPost]
        public RedirectToRouteResult AddStudentEquipment(AddStudentEquipment model)
        {
            return this.RedirectToAction(c => c.ChangeStudentEquipment(model.TemplateId));
        }
        
        [HttpPost]
        public RedirectToRouteResult ChangeRoom(Models.Template.InputModels.ChangeRoom model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }


        [NonAction]
        private ITemplateList GetTemplateList()
        {
            return new Index(
                new[]
                    {
                        new TemplateListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "Basic College Algebra"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "Computer Lab Algebra"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "Online Algebra"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 1302 Trigonometry", "Basic Trigonometry"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 2301 Calculus 1", "Basic Calculus 1"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 2301 Calculus 1", "Calculus 1 Online"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 2302 Calculus 2", "Basic Calculus 2"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 0309 Developmental Math 3",
                                             "Basic Developmental Math 3"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 0308 Developmental Math 2",
                                             "Basic Developmental Math 2"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 0307 Developmental Math 1",
                                             "Basic Developmental Math 1")
                    });
        }

        [NonAction]
        private Details GetDetails(Guid Id)
        {
            var templates = GetTemplateList().Templates;
            return new Details(
                templates,
                Id,
                "MATH 2301 Calculus 1",
                "Calculus 1 Online",
                25,
                null,
                null,
                new[] {"1 Whiteboard", "1 PC", "1 Projector"},
                new[] {"1 PC per student"},
                true,
                true,
                true,
                true,
                Url.Action("ChangeInstructor", new {Id = Id}));
        }

        [NonAction]
        private Models.Template.ViewModels.ChangeInstructor GetChangeInstructor(Guid Id)
        {
            var instructors = new Dictionary<Guid, string>()
                                  {
                                      {Guid.NewGuid(), "John Smith"},
                                      {Guid.NewGuid(), "Joe Smith"},
                                      {Guid.NewGuid(), "Jim Smith"},
                                      {Guid.NewGuid(), "James Smith"},
                                      {Guid.NewGuid(), "Jane Smith"},
                                      {Guid.NewGuid(), "Juan Smith"}
                                  };
            var templates = GetTemplateList().Templates;
            return new Models.Template.ViewModels.ChangeInstructor(
                templates,
                Id,
                "Calculus 1 Online",
                "MATH 2301 Calculus 1",
                instructors);
        }

        [NonAction]
        private ChangeInstructorEquipment GetInstructorEquipment(Guid Id)
        {
            var templates = GetTemplateList().Templates;
            return new ChangeInstructorEquipment(
                templates,
                Id,
                "MATH 2301 Calculus 1",
                "Calculus 1 Online",
                GetEquipmentList().ToDictionary(
                    i => Guid.NewGuid(),
                    i => i),
                new Dictionary<Guid, string>()
                    {
                        {Guid.NewGuid(), "1 Whiteboard"},
                        {Guid.NewGuid(), "1 PC"},
                        {Guid.NewGuid(), "1 Projector"}
                    });
        }

        [NonAction]
        private ChangeStudentEquipment GetStudentEquipment(Guid Id)
        {
            var templates = GetTemplateList().Templates;
            return new ChangeStudentEquipment(
                templates,
                Id,
                "MATH 2301 Calculus 1",
                "Calculus 1 Online",
                GetEquipmentList().ToDictionary(
                    i => Guid.NewGuid(),
                    i => i),
                new Dictionary<Guid, string>()
                    {
                        {Guid.NewGuid(), "1 PC per student"}
                    });
        }

        [NonAction]
        private IEnumerable<string> GetEquipmentList()
        {
            return new[]
                       {
                           "Whiteboard",
                           "PC",
                           "Projector",
                           "Chalkboard",
                           "Lab Sink"
                       }.OrderBy(s => s);
        }

        [NonAction]
        private ChangeRoom GetChangeRoom(Guid Id)
        {
            var templates = GetTemplateList().Templates;

            return new ChangeRoom(
                templates,
                Id,
                "MATH 2301 Calculus 1",
                "Calculus 1 Online",
                new[]
                    {
                        new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "100", RoomStatuses.Available),
                        new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "105", RoomStatuses.Unavailable,
                                             "MATH 0309.01"),
                        new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "111", RoomStatuses.MissingEquipment,
                                             "Missing 1 whiteboard"),
                        new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "112", RoomStatuses.Available),
                        new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "126", RoomStatuses.ReducedCapacity,
                                             "Capacity: 17"),
                        new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "127", RoomStatuses.Available),
                        new RoomAvailability(Guid.NewGuid(), "ACC", "G", "1", "129", RoomStatuses.Unavailable,
                                             "ENGL 1302.01")
                    });
        }

    }
}
