using System;
using Ncqrs.Commanding;

namespace ISIS.Commands
{
    public class ChangeCourseCIP : CommandBase 
    {
        public Guid CourseId { get; private set; }

        public string CIP { get; private set; }

        public ChangeCourseCIP(Guid courseId, string cip)
        {
            CourseId = courseId;
            CIP = cip;
        }
    }
}
