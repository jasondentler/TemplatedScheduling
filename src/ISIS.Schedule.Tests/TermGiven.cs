using System;
using ISIS.Scheduling;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class TermGiven
    {

        [Given(@"I created a term ([^\s]*) ""(.*)"" from ([\d/]*) to ([\d/]*)")]
        public void GivenICreatedATerm(
            string abbreviation,
            string name,
            string startDateString,
            string endDateString)
        {
            var termId = DomainHelper.Id<Term>();
            var startDate = DateTime.Parse(startDateString);
            var endDate = DateTime.Parse(endDateString);
            var @event = new TermCreated(termId, abbreviation, name, startDate, endDate, false);
            DomainHelper.Given<Term>(@event);
        }

        [Given(@"I created a CE term ([^\s]*) ""(.*)"" from ([\d/]*) to ([\d/]*)")]
        public void GivenICreatedACETerm(
            string abbreviation,
            string name,
            string startDateString,
            string endDateString)
        {
            var termId = DomainHelper.Id<Term>();
            var startDate = DateTime.Parse(startDateString);
            var endDate = DateTime.Parse(endDateString);
            var @event = new TermCreated(termId, abbreviation, name, startDate, endDate, true);
            DomainHelper.Given<Term>(@event);
        }

        [Given(@"I have set up a term")]
        [Given(@"I have created a term")]
        public void GivenIHaveCreatedATerm()
        {
            GivenICreatedATerm("211FA", "Fall 2011 16-week", "9/1/2011", "12/15/2011");
        }

        [Given(@"I have created a CE term")]
        public void GivenIHaveCreatedACETerm()
        {
            GivenICreatedACETerm("CE211Q1", "2011 Quarter 1", "9/1/2011", "12/15/2011");
        }


    }
}
