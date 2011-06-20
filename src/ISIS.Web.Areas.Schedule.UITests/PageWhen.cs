using System.Linq;
using NUnit.Framework;
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
            if (elementText.StartsWith(@"""") && elementText.EndsWith(@""""))
                elementText = elementText.Substring(1, elementText.Length - 2);

            var links = Driver.FindElements(By.TagName("a"));
            var buttons = Driver.FindElements(By.ClassName("ui-button-text"));

            var clickables = links.Union(buttons);
            var matchingClickables = clickables
                .Where(i => i.Text == elementText)
                .ToArray();

            if (!matchingClickables.Any())
                Assert.Fail("No link or button with text {0} was found.", elementText);

            if (matchingClickables.Count() > 1)
                Assert.Fail("Multiple links and/or buttons with text {0} were found.", elementText);

            var item = matchingClickables.Single();
            item.Click();
        }

        [When(@"I navigate to the scheduling area")]
        public void WhenINavigateToTheSchedulingArea()
        {
            GoTo("~/Schedule");
        }

        [When(@"I navigate to ~(.+)")]
        public void WhenINavigateTo(string relativeUrlWithoutTilde)
        {
            var relativeUrl = "~" + relativeUrlWithoutTilde;
            GoTo(relativeUrl);
        }




    }
}
