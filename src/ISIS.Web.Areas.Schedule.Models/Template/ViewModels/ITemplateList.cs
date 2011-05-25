using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Template.ViewModels
{

    public interface ITemplateList
    {

        IEnumerable<TemplateListItem> Templates { get; }
        string CourseName { get; }

    }

}
