using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{

    public class AssignCourseToInstructor : CommandBase 
    {

        public Guid InstructorId { get; private set; }
        public Guid CourseId { get; private set; }

        public AssignCourseToInstructor(Guid instructorId, Guid courseId)
        {
            InstructorId = instructorId;
            CourseId = courseId;
        }

    }

}
