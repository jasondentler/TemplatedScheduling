using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ISIS.Web.Models
{
    public interface IJsonSerializable
    {

        IHtmlString ToJson();

    }
}
