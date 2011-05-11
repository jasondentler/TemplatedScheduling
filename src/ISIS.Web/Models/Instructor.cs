using System;
using System.Collections.Generic;

namespace ISIS.Web.Models
{
    public class Instructor
    {

        public Instructor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = Guid.NewGuid();
            Courses = new List<Course>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Course> Courses { get; private set; }

    }
}