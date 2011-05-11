using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class CreateSectionValidatorFixture
        : ConventionValidationFixture<CreateSection>
    {
        protected override CreateSection GetValidInstance()
        {
            return new CreateSection(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "01");
        }

        [Then]
        public void SectionIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new CreateSection(
                          id,
                          Guid.NewGuid(),
                          "01"),
                cmd => cmd.SectionId);
        }

        [Then]
        public void TemplateIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new CreateSection(
                          Guid.NewGuid(),
                          id,
                          "01"),
                cmd => cmd.TemplateId);
        }

        [Then]
        public void SectionNumberIsNotNull()
        {
            GetFailure(
                new CreateSection(Guid.NewGuid(), Guid.NewGuid(), null),
                cmd => cmd.SectionNumber);
        }

        [Then]
        public void SectionNumberIsNotEmpty()
        {
            GetFailure(
                new CreateSection(Guid.NewGuid(), Guid.NewGuid(), string.Empty),
                cmd => cmd.SectionNumber);
        }

        [Then]
        public void SectionNumberCantBeLowerCase()
        {
            GetFailure(
                new CreateSection(Guid.NewGuid(), Guid.NewGuid(), "01m"),
                cmd => cmd.SectionNumber);
        }

        [Then]
        public void SectionNumberCantHaveSpaces()
        {
            GetFailure(
                new CreateSection(Guid.NewGuid(), Guid.NewGuid(), "01 M"),
                cmd => cmd.SectionNumber);
        }

        [Then]
        public void SectionNumberCantHaveUnderscores()
        {
            GetFailure(
                new CreateSection(Guid.NewGuid(), Guid.NewGuid(), "01_M"),
                cmd => cmd.SectionNumber);
        }

        [Then]
        public void SectionNumberCantHaveCommas()
        {
            GetFailure(
                new CreateSection(Guid.NewGuid(), Guid.NewGuid(), "01,M"),
                cmd => cmd.SectionNumber);
        }

        [Then]
        public void SectionNumberCantHavePeriods()
        {
            GetFailure(
                new CreateSection(Guid.NewGuid(), Guid.NewGuid(), "01.M"),
                cmd => cmd.SectionNumber);
        }



    }
}
