using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ISIS.Web.Areas.Schedule.UITests
{
    [Binding]
    public class PageWhen : SeleniumFixture
    {

        [When(@"I click (.*)")]
        public void WhenIClick(string elementText)
        {
            var link = Driver.FindElement(By.LinkText(elementText));
            link.Click();
        }

        [When(@"I navigate to the scheduling area")]
        public void WhenINavigateToTheSchedulingArea()
        {
            GoTo("~/Schedule");
        }


    }
}
