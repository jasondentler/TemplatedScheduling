using TechTalk.SpecFlow;

namespace ISIS.Web.Areas.Schedule.UITests
{
    [Binding]
    public class ISISHomePage_When : SeleniumFixture
    {

        [When(@"I navigate to the ISIS home page")]
        public void WhenINavigateToTheISISHomePage()
        {
            GoHome();
        }

    }
}
