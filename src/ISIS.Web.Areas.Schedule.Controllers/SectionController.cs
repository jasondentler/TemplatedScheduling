using System;
using System.Web.Mvc;
using ISIS.Web.Areas.Schedule.Models.Section.ViewModels;

namespace ISIS.Web.Areas.Schedule.Controllers
{
    public class SectionController : ControllerBase
    {

        [HttpGet]
        public ActionResult Index()
        {
            return Request.IsAjaxRequest()
                       ? (ActionResult)Json(GetSectionList(), JsonRequestBehavior.AllowGet)
                       : View(GetSectionList());
        }

        [HttpGet]
        public ActionResult Details(Guid Id)
        {
            return Request.IsAjaxRequest()
                       ? (ActionResult)Json(GetSectionDetails(Id), JsonRequestBehavior.AllowGet)
                       : View(GetSectionDetails(Id));
        }

        [NonAction]
        public Index GetSectionList()
        {
            return new Index(
                new[]
                    {
                        new SectionListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "02 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "03 Jane Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "M1 Jane Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 1301 College Algebra", "IM1 Jane Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 1302 Trigonometry", "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 2301 Calculus 1", "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 2301 Calculus 1", "02 Jane Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 2302 Calculus 2", "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 0309 Developmental Math 3",
                                             "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 0308 Developmental Math 2",
                                             "01 John Smith"),
                        new SectionListItem(Guid.NewGuid(), "MATH 0307 Developmental Math 1",
                                             "01 John Smith")
                    });
        }

        [NonAction]
        public Details GetSectionDetails(Guid id)
        {
            var sections = GetSectionList().Sections;
            return new Details(
                sections,
                id,
                "MATH 2301.02 Calculus 1",
                "MATH 2301 Calculus 1",
                "Mini 1",
                25,
                "D105",
                "Jane Smith",
                "MW 8:00 a.m. to 9:30 a.m.",
                new[] {"1 Whiteboard", "1 PC", "1 Projector"},
                new string[0]);
        }


    }
}
