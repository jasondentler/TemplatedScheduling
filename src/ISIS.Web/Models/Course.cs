using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIS.Web.Models
{
    public class Course
    {

        public Course(string rubric, string courseNumber, string title)
        {
            Rubric = rubric;
            CourseNumber = courseNumber;
            Title = title;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Rubric { get; set; }
        public string CourseNumber { get; set; }
        public string Title { get; set; }
        
    }
}