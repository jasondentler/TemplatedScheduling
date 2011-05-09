using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class AssignCourseToInstructorValidatorFixture
        : ConventionValidationFixture<AssignCourseToInstructor>
    {
        protected override AssignCourseToInstructor GetValidInstance()
        {
            return new AssignCourseToInstructor(
                Guid.NewGuid(),
                Guid.NewGuid());
        }

        [Then]
        public void InstructorIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AssignCourseToInstructor(id, Guid.NewGuid()),
                cmd => cmd.InstructorId);
        }

        [Then]
        public void CourseIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AssignCourseToInstructor(Guid.NewGuid(), id),
                cmd => cmd.CourseId);
        }


    }
}
