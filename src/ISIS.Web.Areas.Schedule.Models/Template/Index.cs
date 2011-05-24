using System.Collections.Generic;
using ISIS.Web.Models;

namespace ISIS.Web.Areas.Schedule.Models.Template
{
    public class Index : JsonSerializable, ITemplateList
    {
        public IEnumerable<TemplateListItem> Templates { get; private set; }

        public Index(IEnumerable<TemplateListItem> templates)
        {
            Templates = templates;
        }

    }
}
