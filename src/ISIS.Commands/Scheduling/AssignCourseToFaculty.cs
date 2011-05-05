using System;
using Ncqrs.Commanding;

namespace ISIS.Scheduling
{

    public class AssignCourseToFaculty : CommandBase 
    {

        public Guid FacultyId { get; private set; }
        public Guid CourseId { get; private set; }

        public AssignCourseToFaculty(Guid facultyId, Guid courseId)
        {
            FacultyId = facultyId;
            CourseId = courseId;
        }

    }

}
