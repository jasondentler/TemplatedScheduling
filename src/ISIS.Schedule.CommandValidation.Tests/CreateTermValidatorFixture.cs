using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class CreateTermValidatorFixture
        : ConventionValidationFixture<CreateTerm>
    {
        protected override CreateTerm GetValidInstance()
        {
            return new CreateTerm(
                Guid.NewGuid(),
                "211FA",
                "Fall 2011 16-week",
                DateTime.Today.AddMonths(1),
                DateTime.Today.AddMonths(4),
                true);
        }

        [Then]
        public void TermIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new CreateTerm(
                          id,
                          "211FA",
                          "Fall 2011 16-week",
                          DateTime.Today.AddMonths(1),
                          DateTime.Today.AddMonths(4),
                          true),
                cmd => cmd.TermId);
        }

        [Then]
        public void AbbreviationFollowsAbbreviationRules()
        {
            FollowsAbbreviationRules(
                abbreviation => new CreateTerm(
                          Guid.NewGuid(),
                          abbreviation,
                          "Fall 2011 16-week",
                          DateTime.Today.AddMonths(1),
                          DateTime.Today.AddMonths(4),
                          true),
                cmd => cmd.Abbreviation);
        }

        [Then]
        public void NameFollowsShortStringRules()
        {
            FollowsShortStringRules(
                name => new CreateTerm(
                            Guid.NewGuid(),
                            "211FA",
                            name,
                            DateTime.Today.AddMonths(1),
                            DateTime.Today.AddMonths(4),
                            true),
                cmd => cmd.Name);
        }

        [Then]
        public void StartBeforeEndDate()
        {
            GetFailure(
                new CreateTerm(Guid.NewGuid(),
                               "211FA",
                               "Fall 2011 16-week",
                               DateTime.Today,
                               DateTime.Today.AddDays(-1),
                               true),
                cmd => cmd.Start);
        }

        [Then]
        public void StartNotOnSameDayAsEndDate()
        {
            GetFailure(
                new CreateTerm(Guid.NewGuid(),
                               "211FA",
                               "Fall 2011 16-week",
                               DateTime.Today,
                               DateTime.Today,
                               true),
                cmd => cmd.Start);
        }

        [Then]
        public void StartWithoutTime()
        {
            GetFailure(
                new CreateTerm(Guid.NewGuid(),
                               "211FA",
                               "Fall 2011 16-week",
                               DateTime.Now.AddMonths(1),
                               DateTime.Today.AddMonths(4),
                               true),
                cmd => cmd.Start);
        }

        [Then]
        public void EndWithoutTime()
        {
            GetFailure(
                new CreateTerm(Guid.NewGuid(),
                               "211FA",
                               "Fall 2011 16-week",
                               DateTime.Today.AddMonths(1),
                               DateTime.Now.AddMonths(4),
                               true),
                cmd => cmd.End);
        }

    }
}
