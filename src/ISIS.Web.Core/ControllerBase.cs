using System.Text;
using System.Web.Mvc;

namespace ISIS.Web
{
    public class ControllerBase : Controller 
    {
        
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new BetterJsonResult()
                       {
                           Data = data,
                           ContentType = contentType,
                           ContentEncoding = contentEncoding,
                           JsonRequestBehavior = behavior
                       };
        }

    }
}
