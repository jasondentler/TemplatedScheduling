using System.Web.Mvc;

namespace ISIS.Web.Areas.Facilities
{
    public class FacilitiesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Facilities";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Facilities_default",
                "Facilities/{controller}/{action}/{id}",
                new { controller = "Campus", action = "Index", id = UrlParameter.Optional },
                new[] { "ISIS.Web.Areas.Facilities.Controllers" }
                );
        }
    }
}
