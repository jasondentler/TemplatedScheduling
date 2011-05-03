using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{
    public class ChangeCourseDescription : CommandBase 
    {
        public Guid CourseId { get; private set; }

        public string Description { get; private set; }

        public ChangeCourseDescription(Guid courseId, string description)
        {
            CourseId = courseId;
            Description = description;
        }
    }
}
