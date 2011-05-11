using System;
using System.Linq;
using System.Web.Mvc;
using ISIS.Web.Models;

namespace ISIS.Web.Controllers
{
    public class TemplateController : Controller
    {
        //
        // GET: /Template/

        public ActionResult Index()
        {
            var model = Data.Templates.AllTemplates
                .Where(t => Data.Courses.AllMath.Contains(t.Course));

            return View(model);
        }

        public ActionResult Details(Guid id)
        {
            var model = Data.Templates.AllTemplates
                .Where(t => t.Id == id)
                .Single();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = Data.Templates.AllTemplates
                .Where(t => t.Id == id)
                .Single();
            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult Edit(Models.ViewModels.TemplateViewModel viewModel)
        {
            var model = Data.Templates.AllTemplates
                .Where(t => t.Id == viewModel.Id)
                .Single();

            model.Label = viewModel.Label;
            model.MaxCapacity = viewModel.MaxCapacity;

            return RedirectToAction("Index");
        }

    }
}
