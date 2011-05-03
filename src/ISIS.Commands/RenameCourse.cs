using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{
    public class RenameCourse : CommandBase 
    {

        public Guid CourseId { get; private set; }
        public string NewTitle { get; private set; }
        public string NewShortTitle { get; private set; }

        public RenameCourse(Guid courseId, string newTitle, string newShortTitle)
        {
            CourseId = courseId;
            NewTitle = newTitle;
            NewShortTitle = newShortTitle;
        }


    }
}
