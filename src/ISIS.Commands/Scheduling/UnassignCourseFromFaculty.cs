using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{

    public class UnassignCourseFromFaculty : CommandBase 
    {

        public Guid FacultyId { get; private set; }
        public Guid CourseId { get; private set; }

        public UnassignCourseFromFaculty(Guid facultyId, Guid courseId)
        {
            FacultyId = facultyId;
            CourseId = courseId;
        }

    }

}
