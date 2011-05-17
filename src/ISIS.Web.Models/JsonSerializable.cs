using System.Web;
using Newtonsoft.Json;

namespace ISIS.Web.Models
{
    public class JsonSerializable : IJsonSerializable
    {
        public IHtmlString ToJson()
        {
            var dataString = JsonConvert.SerializeObject(this);
            return new HtmlString(dataString);
        }
    }
}
