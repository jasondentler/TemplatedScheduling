using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class CreateCourseValidatorFixture
        : ConventionValidationFixture<CreateCourse>
    {
        protected override CreateCourse GetValidInstance()
        {
            return new CreateCourse(
                Guid.NewGuid(),
                "BIOL",
                "1301");
        }

        [Then]
        public void TermIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new CreateCourse(
                id,
                "BIOL",
                "1301"),
                cmd => cmd.CourseId);
        }

        [Then]
        public void RubricFollowsRubricRules()
        {
            FollowsRubricRules(
                rubric => new CreateCourse(
                              Guid.NewGuid(),
                              rubric,
                              "1301"),
                cmd => cmd.Rubric);
        }

    }
}
