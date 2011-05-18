using System;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ISIS.Web
{
    public class BetterJsonResult : JsonResult
    {

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = !String.IsNullOrEmpty(ContentType) 
                ? ContentType 
                : "application/json";

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                response.Write(JsonConvert.SerializeObject(Data));
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                //response.Write(serializer.Serialize(Data));
            }
        }
    }
}
