using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class DomainSteps
    {
        [Then(@"it does nothing else")]
        public void ThenItDoesNothingElse()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
