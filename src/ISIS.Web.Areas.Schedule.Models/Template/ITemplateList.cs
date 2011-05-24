using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Template
{

    public interface ITemplateList
    {

        IEnumerable<TemplateListItem> Templates { get; }

    }

}
