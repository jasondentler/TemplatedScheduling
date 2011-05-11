using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIS.Web.Models.ViewModels
{
    public class TemplateViewModel
    {

        public Guid Id { get; set; }
        public string Label { get; set; }
        public int MaxCapacity { get; set; }

    }
}