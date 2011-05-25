using System;

namespace ISIS.Web.Areas.Schedule.Models.Instructor.InputModels
{
    public class Rename
    {

        public Guid Id { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }

    }
}
