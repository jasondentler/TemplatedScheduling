using System;
using System.Web.Mvc;
using ISIS.Web.Areas.Schedule.Models.Template;
using Microsoft.Web.Mvc;

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

        [NonAction]
        private ITemplateList GetTemplateList()
        {
            return new Index(
                new []
                    {
                        new TemplateListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "Basic College Algebra"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "Computer Lab Algebra"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "Online Algebra"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 1302 Trigonometry", "Basic Trigonometry"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 2301 Calculus 1", "Basic Calculus 1"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 2302 Calculus 2", "Basic Calculus 2"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 0309 Developmental Math 3", "Basic Developmental Math 3"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 0308 Developmental Math 2", "Basic Developmental Math 2"),
                        new TemplateListItem(Guid.NewGuid(), "MATH 0307 Developmental Math 1", "Basic Developmental Math 1")
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
                "Basic Calculus 1",
                25,
                null,
                null,
                new[] {"1 Whiteboard", "1 PC", "1 Projector"},
                new string[0],
                false,
                false,
                false,
                false);
        }

    }
}
