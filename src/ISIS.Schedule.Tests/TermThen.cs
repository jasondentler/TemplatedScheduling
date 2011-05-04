using System;
using ISIS.Scheduling;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Schedule
{
    [Binding]
    public class TermThen
    {

        [Then(@"the term is created")]
        public void ThenTheTermIsCreated()
        {
            var e = DomainHelper.Then<TermCreated>();
            e.TermId.Should().Be.EqualTo(DomainHelper.Id<Term>());
        }

        [Then(@"the term abbreviation is ([^\s]*)")]
        public void ThenTheTermAbbreviationIs(
            string termAbbreviation)
        {
            var e = DomainHelper.Then<TermCreated>();
            e.Abbreviation.Should().Be.EqualTo(termAbbreviation);
        }

        [Then(@"the term name is ""(.*)""")]
        public void ThenTheTermNameIs(
            string termName)
        {
            var e = DomainHelper.Then<TermCreated>();
            e.Name.Should().Be.EqualTo(termName);
        }

        [Then(@"the term start date is ([\d/]*)")]
        public void ThenTheTermStartDateIs(
            string startDateString)
        {
            var startDate = DateTime.Parse(startDateString);
            var e = DomainHelper.Then<TermCreated>();
            e.StartDate.Should().Be.EqualTo(startDate);
        }

        [Then(@"the term end date is ([\d/]*)")]
        public void ThenTheTermEndDateIs(
            string endDateString)
        {
            var endDate = DateTime.Parse(endDateString);
            var e = DomainHelper.Then<TermCreated>();
            e.EndDate.Should().Be.EqualTo(endDate);
        }

        [Then(@"the term is renamed from ""([^""]*)"" to ""([^""]*)""")]
        public void ThenTheTermIsRenamed(
            string oldName,
            string newName)
        {
            var e = DomainHelper.Then<TermRenamed>();
            e.OldName.Should().Be.EqualTo(oldName);
            e.NewName.Should().Be.EqualTo(newName);
        }


    }
}
