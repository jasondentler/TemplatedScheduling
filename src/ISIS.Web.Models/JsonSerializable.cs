using System.Web;
using Newtonsoft.Json;

namespace ISIS.Web.Models
{
    public class JsonSerializable : IJsonSerializable
    {
        public virtual IHtmlString ToJson()
        {
            var dataString = ToJson(this);
            return new HtmlString(dataString);
        }

        protected static string ToJson(object toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize);
        }
    }
}
