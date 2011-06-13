using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISIS.Web.Areas.Facilities.Models.Campus.InputModels
{
    public class RenameCampus
    {

        public Guid CampusId { get; set; }
        public string NewCampusName { get; set; }

    }
}
