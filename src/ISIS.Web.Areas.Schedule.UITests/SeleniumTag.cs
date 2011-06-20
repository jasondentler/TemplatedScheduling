using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace ISIS.Web.Areas.Schedule.UITests
{
    [Binding]
    public class SeleniumTag
    {

        private static readonly IWebDriver driver;

        static SeleniumTag()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
        }


        [BeforeScenario("selenium")]
        public void BeforeSeleniumScenario()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Manage().DeleteAllCookies();
        }

        public static IWebDriver Driver { get { return driver; } }

    }
}
