using System;

namespace ISIS.Scheduling
{
    public class CourseDescriptionChanged
    {

        public Guid CourseId { get; private set; }
        public string OldDescription { get; private set; }
        public string NewDescription { get; private set; }

        public CourseDescriptionChanged(Guid courseId, string oldDescription, string newDescription)
        {
            CourseId = courseId;
            OldDescription = oldDescription;
            NewDescription = newDescription;
        }

    }
}
