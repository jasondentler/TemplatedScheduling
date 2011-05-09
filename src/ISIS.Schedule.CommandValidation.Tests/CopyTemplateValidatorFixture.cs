using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class CopyTemplateValidatorFixture
        : ConventionValidationFixture<CopyTemplate>
    {
        protected override CopyTemplate GetValidInstance()
        {
            return new CopyTemplate(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "Template Label");
        }

        [Then]
        public void NewTemplateIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new CopyTemplate(id, Guid.NewGuid(), "Template Label"),
                cmd => cmd.NewTemplateId);
        }

        [Then]
        public void SourceTemplateIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new CopyTemplate(Guid.NewGuid(), id, "Template Label"),
                cmd => cmd.SourceTemplateId);
        }

        [Then]
        public void NewTemplateLabelFollowsShortStringRules()
        {
            FollowsShortStringRules(
                label => new CopyTemplate(Guid.NewGuid(), Guid.NewGuid(), label),
                cmd => cmd.NewTemplateLabel);
        }

    }
}
