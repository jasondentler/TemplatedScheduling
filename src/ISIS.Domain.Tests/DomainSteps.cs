using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class DomainSteps
    {
        [Then(@"it does nothing else")]
        public void ThenItDoesNothingElse()
        {
            DomainHelper.AllEventsChecked().Should().Be.True();
            DomainHelper.ExceptionThrown().Should().Be.False();
        }

        [Then(@"it does nothing")]
        public void ThenItDoesNothing()
        {
            DomainHelper.NoEvents().Should().Be.True();
            DomainHelper.ExceptionThrown().Should().Be.False();
        }

        [Then(@"the aggregate state is invalid")]
        public void ThenTheAggregateStateIsInvalid()
        {
            var ex = DomainHelper.GetException();
            ex.Should().Be.InstanceOf<InvalidAggregateStateException>();
        }

        [Then(@"the message is ""(.*)""")]
        public void ThenTheMessageIs(
            string message)
        {
            var ex = DomainHelper.GetException();
            ex.Message.Should().Be.EqualTo(message);
        }

    }
}
