using System;

namespace ISIS.Web.Areas.Facilities.Models.Map.InputModels
{
    public class RenameMap
    {

        public Guid MapId { get; set; }
        public string NewMapName { get; set; }

    }
}
