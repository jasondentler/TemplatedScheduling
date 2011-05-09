using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class AssignInstructorToTemplateValidatorFixture
        : ConventionValidationFixture<AssignInstructorToTemplate>
    {
        protected override AssignInstructorToTemplate GetValidInstance()
        {
            return new AssignInstructorToTemplate(
                Guid.NewGuid(),
                Guid.NewGuid());
        }

        [Then]
        public void TemplateIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AssignInstructorToTemplate(id, Guid.NewGuid()),
                cmd => cmd.TemplateId);
        }

        [Then]
        public void InstructorIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AssignInstructorToTemplate(Guid.NewGuid(), id),
                cmd => cmd.InstructorId);
        }


    }
}
