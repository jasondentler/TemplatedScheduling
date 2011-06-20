using System;
using System.Configuration;
using OpenQA.Selenium;

namespace ISIS.Web.Areas.Schedule.UITests
{

    public abstract class SeleniumFixture
    {

        private const string UrlAppSetting = "ISIS.Url";

        private static readonly string  HomeUrl = ConfigurationManager.AppSettings[UrlAppSetting];

        public IWebDriver Driver { get { return SeleniumTag.Driver; }}

        public virtual void GoHome()
        {
            GoTo("~/");
        }

        public virtual void GoTo(string relativeUrl)
        {
            var absoluteUrl = GetAbsoluteUrl(relativeUrl);
            Console.WriteLine("Navigating to {0}", absoluteUrl);
            Driver.Navigate().GoToUrl(absoluteUrl);
        }

        public virtual IRenderedWebElement LinkByText(string text)
        {
            return (IRenderedWebElement) Driver.FindElement(By.LinkText(text));
        }

        public virtual string GetAbsoluteUrl(string relativeUrl)
        {
            if (relativeUrl.StartsWith("~/"))
                return GetAbsoluteUrl(relativeUrl.Remove(0, 2));
            if (relativeUrl.StartsWith("~"))
                return GetAbsoluteUrl(relativeUrl.Remove(0, 1));
            if (relativeUrl.StartsWith("/"))
                return GetAbsoluteUrl(relativeUrl.Remove(0, 1));
            return HomeUrl + relativeUrl;
        }

        public virtual bool UrlIs(string relativeUrl)
        {
            return Driver.Url.Equals(GetAbsoluteUrl(relativeUrl), StringComparison.CurrentCultureIgnoreCase);
        }

    }

}
