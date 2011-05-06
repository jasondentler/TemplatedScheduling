using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class ActivateTemplateValidatorFixture
        : ConventionValidationFixture<ActivateTemplate>
    {
        protected override ActivateTemplate GetValidInstance()
        {
            return new ActivateTemplate(Guid.NewGuid());
        }

        [Then]
        public void TemplateIdFollowsRules()
        {
            FollowsEventSourceIdRules(id => new ActivateTemplate(id), cmd => cmd.TemplateId);
        }
    }
}
