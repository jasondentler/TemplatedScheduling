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
        }
    }
}
