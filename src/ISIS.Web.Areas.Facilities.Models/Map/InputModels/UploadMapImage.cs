using System;
using System.Web;

namespace ISIS.Web.Areas.Facilities.Models.Map.InputModels
{
    public class UploadMapImage
    {

        public Guid MapId { get; set; }
        public HttpPostedFileBase Map { get; set; }

    }
}
