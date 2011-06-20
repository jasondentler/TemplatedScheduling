using System.Linq;
using OpenQA.Selenium;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Web.Areas.Schedule.UITests
{
    [Binding]
    public class DialogThen : SeleniumFixture
    {

        private IWebElement FindDialogTitle(string title)
        {
            var dialogTitleElements = Driver.FindElements(By.ClassName("ui-dialog-title"));

            return dialogTitleElements
                .Where(i => i.Text == title)
                .SingleOrDefault();

        }


        [Then(@"the (.*) dialog is displayed")]
        public void ThenTheDialogIsDisplayed(string title)
        {
            var titleElement = FindDialogTitle(title);
            titleElement.Should().Not.Be.Null();
        }

        [Then(@"the (.*) dialog is not displayed")]
        public void ThenTheDialogIsNotDisplayed(string title)
        {
            var titleElement = FindDialogTitle(title);
            titleElement.Should().Be.Null();
        }

    }
}
