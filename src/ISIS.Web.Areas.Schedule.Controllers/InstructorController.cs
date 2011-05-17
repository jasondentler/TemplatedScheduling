using System;
using System.Web.Mvc;
using ISIS.Web.Areas.Schedule.Models;

namespace ISIS.Web.Areas.Schedule.Controllers
{

    public class InstructorController : Controller
    {

        public ViewResult Index()
        {
            var list = new InstructorList(
                new[]
                    {
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "John Smith"},
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "John Smith"},
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "John Smith"},
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "John Smith"},
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "John Smith"},
                        new InstructorListItem() {Id = Guid.NewGuid(), Name = "John Smith"}
                    });
            return View(list);
        }

    }

}
