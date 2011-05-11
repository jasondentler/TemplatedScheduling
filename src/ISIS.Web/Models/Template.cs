using System;
using System.Collections.Generic;

namespace ISIS.Web.Models
{
    public class Template
    {

        public Template(string label, Course course, int maxCapacity)
        {
            Label = label;
            Id = Guid.NewGuid();
            Course = course;
            MaxCapacity = maxCapacity;
            StudentEquipment = new List<string>();
            InstructorEquipment = new List<string>();
        }

        public Guid Id { get; set; }
        public string Label { get; set; }
        public Course Course { get; set; }
        public Room Room { get; set; }
        public Instructor Instructor { get; set; }
        public List<string> StudentEquipment { get; private set; }
        public List<string> InstructorEquipment { get; private set; }
        public int MaxCapacity { get; set; }

        public string Rubric { get { return Course.Rubric; } }
        public string CourseNumber { get { return Course.CourseNumber; } }
        public string Title { get { return Course.Title; } }


    }
}