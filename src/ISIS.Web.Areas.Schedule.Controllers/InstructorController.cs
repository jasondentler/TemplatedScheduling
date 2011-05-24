using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Areas.Schedule.Models;
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

        [HttpGet]
        public ActionResult Calendar(Guid Id)
        {
            if (Request.IsAjaxRequest())
            {
                return Json(GetCalendar(Id), JsonRequestBehavior.AllowGet);
            }
            return View(GetCalendar(Id));
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

        [HttpPost]
        public RedirectToRouteResult RemoveBlackoutTime(RemoveBlackoutTimes model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult AddBlackoutTime(AddBlackoutTime model)
        {
            return this.RedirectToAction(c => c.Details(model.Id));
        }

        [HttpPost]
        public RedirectToRouteResult RemoveInstructor(Remove model)
        {
            return this.RedirectToAction(c => c.Index());
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
                    },
                new Dictionary<Guid, string>()
                    {
                        {Guid.NewGuid(), "Monday, 12:00 am - 10:00 am"},
                        {Guid.NewGuid(), "Tuesday, 12:00 am - 10:00 am"},
                        {Guid.NewGuid(), "Wednesday, 12:00 am - 10:00 am"},
                        {Guid.NewGuid(), "Thursday, 12:00 am - 10:00 am"},
                        {Guid.NewGuid(), "Friday, 12:00 am - 10:00 am"}
                    });
        }

        private static Random rnd = new Random();

        [NonAction]
        private Calendar GetCalendar(Guid Id)
        {
            return new Calendar(
                Id,
                "John Smith",
                GenerateCalendarItems());
        }

        [NonAction]
        private IEnumerable<CalendarItem> GenerateCalendarItems()
        {
            var itemCount = rnd.Next(0, 20);
            for (var i = 0; i < itemCount; i++)
                yield return GenerateCalendarItem();

            var blackoutCount = rnd.Next(0, 5);
            for (var i = 0; i < blackoutCount; i++)
            {
                var item = GenerateCalendarItem();
                while (!item.Start.HasValue)
                    item = GenerateCalendarItem();

                item.Title = "Unavailable";
                item.Class = "blackout";
                yield return item;
            }
        }

        [NonAction]
        private CalendarItem GenerateCalendarItem()
        {
            var sections = new Dictionary<Guid, string>()
                               {
                                   {Guid.NewGuid(), "MATH 0307.01"},
                                   {Guid.NewGuid(), "MATH 0307.02"},
                                   {Guid.NewGuid(), "MATH 0308.01"},
                                   {Guid.NewGuid(), "MATH 0308.02"},
                                   {Guid.NewGuid(), "MATH 0309.01"},
                                   {Guid.NewGuid(), "MATH 0309.02"},
                                   {Guid.NewGuid(), "MATH 1301.01"},
                                   {Guid.NewGuid(), "MATH 1301.02"},
                                   {Guid.NewGuid(), "MATH 1301.03"},
                                   {Guid.NewGuid(), "MATH 1301.IN"},
                                   {Guid.NewGuid(), "MATH 1301.M1"},
                                   {Guid.NewGuid(), "MATH 1302.01"},
                                   {Guid.NewGuid(), "MATH 2301.01"},
                                   {Guid.NewGuid(), "MATH 2301.02"},
                                   {Guid.NewGuid(), "MATH 2302.01"}
                               };
            var section = GetRandomItem(sections);
            var schedule = GetRandomTimespan();
            return new CalendarItem()
                       {
                           Id = section.Key,
                           Title = section.Value,
                           Description = "John Smith",
                           Start = schedule[0],
                           End = schedule[1]
                       };
        }

        [NonAction]
        private T GetRandomItem<T>(IEnumerable<T> items)
        {
            var index = rnd.Next(items.Count());
            return items.ElementAt(index);
        }

        [NonAction]
        private DateTime?[] GetRandomTimespan()
        {
            if (rnd.Next(2) == 0)
                return new DateTime?[] {null, null};

            var dayOfWeek = rnd.Next(7);
            var startHour = rnd.Next(4, 23);
            var endHour = rnd.Next(startHour, 24);
            
            // May 8,2011 was a Sunday
            var date = new DateTime(2011, 5, 8).AddDays(dayOfWeek);
            var start = date.AddHours(startHour);
            var end = date.AddHours(endHour);
            return new DateTime?[] {start, end};
        }

    }

}
