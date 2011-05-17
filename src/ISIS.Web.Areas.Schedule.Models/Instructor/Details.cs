using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Instructor
{
    public class Details : Index
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ISet<string> Courses { get; private set; }

        public Details(IEnumerable<InstructorListItem> instructors,
            Guid Id,
            string firstName,
            string lastName,
            ISet<string> courses)
            : base(instructors)
        {
            this.Id = Id;
            FirstName = firstName;
            LastName = lastName;
            Courses = courses;
        }
    }
}
