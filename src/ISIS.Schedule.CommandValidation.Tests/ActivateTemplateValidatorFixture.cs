using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    [Specification]
    public class ActivateTemplateValidatorFixture
        : ConventionValidationFixture<ActivateTemplate>
    {
        protected override ActivateTemplate GetValidInstance()
        {
            return new ActivateTemplate(Guid.NewGuid());
        }

        [Then]
        public void TemplateIdIsRequired()
        {
            GetFailure(new ActivateTemplate(default(Guid)),
                       cmd => cmd.TemplateId);
        }
    }
}
