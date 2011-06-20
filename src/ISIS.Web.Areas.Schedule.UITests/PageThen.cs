using System.Linq;
using OpenQA.Selenium;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Web.Areas.Schedule.UITests
{
    [Binding]
    public class PageThen : SeleniumFixture
    {

        [Then(@"the page has breadcrumbs as follows")]
        public void ThenThePageHasBreadcrumbsAsFollows(Table table)
        {

            var crumbList = Driver.FindElement(By.ClassName("breadcrumbs"));
            var listItems = crumbList.FindElements(By.TagName("li"));

            var crumbs = listItems.Where(li => li.GetAttribute("class") != "separator").ToArray();

            crumbs.Count().Should().Be.EqualTo(table.RowCount);

            var data = crumbs.Zip(table.Rows, (li, row) => new {li, text = row["Text"], url = row["Url"]});

            foreach (var item in data)
            {
                if (!string.IsNullOrWhiteSpace(item.url))
                {
                    var a = item.li.FindElement(By.TagName("a"));
                    a.Text.Should().Be.EqualTo(item.text);
                    a.GetAttribute("href").Should().Be.EqualTo(item.url);
                }
                else
                {
                    item.li.Text.Should().Be.EqualTo(item.text);
                }
            }

        }

        [Then(@"the page has a link to (.+)")]
        public void ThenThePageHasALinkTo(string linkText)
        {
            var link = LinkByText(linkText);
            link.Should().Not.Be.Null();
        }


        [Then(@"I navigate to the Scheduling area")]
        public void ThenINavigateToTheSchedulingArea()
        {
            UrlIs("~/Schedule").Should().Be.True();
        }

        [Then(@"I navigate to the Facilities area")]
        public void ThenINavigateToTheFacilitiesArea()
        {
            UrlIs("~/Facilities").Should().Be.True();
        }

        [Then(@"I navigate to the ISIS home page")]
        public void ThenINavigateToTheISISHomePage()
        {
            UrlIs("~/").Should().Be.True();
        }

        [Then(@"I navigate to ~(.+)")]
        public void ThenINavigateTo(string relativeUrlWithoutTilde)
        {
            var relativeUrl = "~" + relativeUrlWithoutTilde;
            UrlIs(relativeUrl).Should().Be.True();
        }

        [Then(@"the page has a hint ""(.*)""")]
        public void ThenThePageHasAHint(string hintText)
        {
            var hint = Driver.FindElement(By.ClassName("hint"));
            hint.Text.Should().Be.EqualTo(hintText);
        }

    }
}
