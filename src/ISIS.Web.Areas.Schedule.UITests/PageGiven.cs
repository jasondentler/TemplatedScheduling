using TechTalk.SpecFlow;

namespace ISIS.Web.Areas.Schedule.UITests
{
    [Binding]
    public class PageGiven : SeleniumFixture
    {

        [Given(@"I have navigated to the ISIS home page")]
        public void GivenIHaveNavigatedToTheISISHomePage()
        {
            GoHome();
        }

        [Given(@"I navigate to the scheduling area")]
        public void GivenINavigateToTheSchedulingArea()
        {
            GoTo("~/Schedule");
        }


    }
}
