using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Schedule.Models;
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

        [HttpGet]
        public ActionResult RoomAvailability(Guid id, string map)
        {
            return Json(GetRoomAvailability(id, map), JsonRequestBehavior.AllowGet);
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
                        new Campus("Main Campus",
                                   new[]
                                       {
                                           new Building("A",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/A1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/A1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=A1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/A2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/A2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=A2",
                                                                                    Id)))
                                                            }),
                                           new Building("B",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/B1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/B1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=B1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/B2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/B2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=B2",
                                                                                    Id)))
                                                            }),
                                           new Building("C",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/C1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/C1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=C1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/C2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/C2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=C2",
                                                                                    Id)))
                                                            }),
                                           new Building("D",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/D1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/D1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=D1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/D2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/D2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=D2",
                                                                                    Id)))
                                                            }),
                                           new Building("E",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/E1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/E1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=E1",
                                                                                    Id)))
                                                            }),
                                           new Building("F",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/F1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/F1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=F1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/F2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/F2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=F2",
                                                                                    Id)))
                                                            }),
                                           new Building("G",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/G1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/G1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=G2",
                                                                                    Id)))
                                                            }),
                                           new Building("H",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/H1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/H1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=H1",
                                                                                    Id)))
                                                            }),
                                           new Building("J",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/J1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/J1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=J1",
                                                                                    Id)))
                                                            }),

                                           new Building("K",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/K1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/K1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=K1",
                                                                                    Id)))
                                                            }),

                                           new Building("N",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/N1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/N1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=N1",
                                                                                    Id)))
                                                            }),
                                           new Building("Nolan Ryan Center",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/NRC1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/NRC1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=NRC1",
                                                                                    Id)))
                                                            }),
                                           new Building("S",
                                                        new[]
                                                            {
                                                                new BuildingMap("1st Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/S1.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/S1.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=S1",
                                                                                    Id))),
                                                                new BuildingMap("2nd Floor",
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/S2.svg"),
                                                                                Url.Content(
                                                                                    "~/Content/images/buildings/S2.js"),
                                                                                Url.Content(string.Format(
                                                                                    "~/Schedule/Template/RoomAvailability/{0}?map=S2",
                                                                                    Id)))
                                                            })
                                       }),
                        new Campus("Pearland Campus", new Building[0])
                    });

        }

        [NonAction]
        private IEnumerable<RoomAvailability> GetRoomAvailability(Guid id, string map)
        {
            return new[]
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
                       };
        }



    }
}
