using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{
    public class ChangeCourseTitle : CommandBase 
    {
        public Guid CourseId { get; private set; }

        public string NewTitle { get; private set; }

        public ChangeCourseTitle(Guid courseId, string newTitle)
        {
            CourseId = courseId;
            NewTitle = newTitle;
        }


    }
}
