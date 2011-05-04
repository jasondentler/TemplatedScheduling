using System;
using ISIS.Commands;
using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class TermWhen
    {

        [When(@"I create a term ([^\s]*) ""(.*)"" from ([\d/]*) to ([\d/]*)")]
        public void WhenICreateATerm(
            string abbreviation,
            string name,
            string startDateString,
            string endDateString)
        {
            var startDate = DateTime.Parse(startDateString);
            var endDate = DateTime.Parse(endDateString);
            var termId = DomainHelper.Id<Term>();
            var cmd = new CreateTerm(termId, abbreviation, name, startDate, endDate);
            DomainHelper.When(cmd);
        }

        [When(@"I rename the term to ""(.*)""")]
        public void WhenIRenameTheTermTo(
            string name)
        {
            var termId = DomainHelper.Id<Term>();
            var cmd = new RenameTerm(termId, name);
            DomainHelper.When(cmd);
        }

    }
}
