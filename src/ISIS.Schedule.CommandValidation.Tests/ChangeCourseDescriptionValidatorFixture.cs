using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class ChangeCourseDescriptionValidatorFixture
        : ConventionValidationFixture<ChangeCourseDescription>
    {
        protected override ChangeCourseDescription GetValidInstance()
        {
            return new ChangeCourseDescription(
                Guid.NewGuid(),
                "Description goes here");
        }

        [Then]
        public void CourseIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new ChangeCourseDescription(id, "Description goes here"),
                cmd => cmd.CourseId);
        }

        [Then]
        public void DescriptionFollowsStringRules()
        {
            FollowsStringRules(
                description => new ChangeCourseDescription(Guid.NewGuid(), description),
                cmd => cmd.Description);
        }

        [Then]
        public void DescriptionLessThan1KCharacters()
        {
            var description = "A".PadLeft(1025, 'A');

            GetFailure(new ChangeCourseDescription(Guid.NewGuid(), description),
                       cmd => cmd.Description);
        }

    }
}
