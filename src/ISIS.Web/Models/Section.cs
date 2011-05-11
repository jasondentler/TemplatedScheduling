using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIS.Web.Models
{
    public class Section
    {

        public Guid Id { get; set; }
        public string Rubric { get; set; }
        public string CourseNumber { get; set; }
        public string Title { get; set; }
        public string SectionNumber { get; set; }
        public Room Room { get; set; }
        public Instructor Instructor { get; set; }

    }
}