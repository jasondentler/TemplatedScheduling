using System;
using System.Collections.Generic;

namespace ISIS.Web.Areas.Schedule.Models.Instructor
{
    public class Details : Index
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IDictionary<Guid, string> Courses { get; private set; }
        public IDictionary<Guid, string> AvailableCourses { get; private set; }
        public IDictionary<Guid, string> BlackoutTimes { get; private set; }
        public IDictionary<int, string> BlackoutDaysOfTheWeek { get; private set; }
        public IDictionary<int, string> BlackoutStartTimes { get; private set; }
        public IDictionary<int, string> BlackoutEndTimes { get; private set; }

        public Details(IEnumerable<InstructorListItem> instructors,
            Guid id,
            string firstName,
            string lastName,
            IDictionary<Guid, string> courses,
            IDictionary<Guid, string> availableCourses,
            IDictionary<Guid, string> blackoutTimes,
            IDictionary<int, string> blackoutDaysOfTheWeek,
            IDictionary<int, string> blackoutStartTimes,
            IDictionary<int, string> blackoutEndTimes)
            : base(instructors)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Courses = courses;
            AvailableCourses = availableCourses;
            BlackoutTimes = blackoutTimes;
            BlackoutDaysOfTheWeek = blackoutDaysOfTheWeek;
            BlackoutStartTimes = blackoutStartTimes;
            BlackoutEndTimes = blackoutEndTimes;
        }
    }
}
