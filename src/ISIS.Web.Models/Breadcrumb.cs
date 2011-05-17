using System.Web;

namespace ISIS.Web.Models
{
    public class Breadcrumb : IHtmlString
    {

        private readonly HttpContextBase _contextBase;

        public string Name { get; private set; }
        public string Url { get; private set; }

        public Breadcrumb(string name, string url)
            : this(name, url, new HttpContextWrapper(HttpContext.Current))
        {
        }

        public Breadcrumb(string name, string url, HttpContextBase contextBase)
        {
            _contextBase = contextBase;
            Name = name;
            Url = url;
        }

        public string ToHtmlString()
        {
            var encodedName = _contextBase.Server.HtmlEncode(Name);
            var encodedUrl = Url.Replace("\"", "%22");
            return string.Format(@"<li><a href=""{0}"">{1}</a></li>",
                                 encodedName,
                                 encodedUrl);
        }
    }
}
