﻿using System;

namespace ISIS.Web.Areas.Schedule.Models.Template.InputModels
{
    public class Copy
    {

        public Guid SourceId { get; set; }
        public Guid CopyId { get; set; }
        public string CopyName { get; set; }

    }
}
