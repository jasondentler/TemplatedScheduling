using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class AssignTermToTemplateValidatorFixture
        : ConventionValidationFixture<AssignTermToTemplate>
    {
        protected override AssignTermToTemplate GetValidInstance()
        {
            return new AssignTermToTemplate(
                Guid.NewGuid(),
                Guid.NewGuid());
        }

        [Then]
        public void TemplateIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AssignTermToTemplate(id, Guid.NewGuid()),
                cmd => cmd.TemplateId);
        }

        [Then]
        public void TermIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new AssignTermToTemplate(Guid.NewGuid(), id),
                cmd => cmd.TermId);
        }


    }
}
