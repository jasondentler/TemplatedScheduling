using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Web.Areas.Schedule.UITests
{
    [Binding]
    public class Breadcrumbs_Then : SeleniumFixture
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

    }
}
