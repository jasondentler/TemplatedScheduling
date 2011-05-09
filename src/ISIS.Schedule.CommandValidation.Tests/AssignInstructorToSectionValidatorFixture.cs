using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class AssignInstructorToSectionValidatorFixture
        : ConventionValidationFixture<AssignInstructorToSection>
    {
        protected override AssignInstructorToSection GetValidInstance()
        {
            return new AssignInstructorToSection(
                Guid.NewGuid(),
                Guid.NewGuid());
        }

        [Then]
        public void SectionIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AssignInstructorToSection(id, Guid.NewGuid()),
                cmd => cmd.SectionId);
        }

        [Then]
        public void InstructorIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AssignInstructorToSection(Guid.NewGuid(), id),
                cmd => cmd.InstructorId);
        }


    }
}
