using System;
using System.Linq;
using OpenQA.Selenium;
using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Web.Areas.Schedule.UITests.Instructor
{
    [Binding]
    public class InstructorsThen : SeleniumFixture
    {
        
        [Then(@"the page has a list of instructors")]
        public void ThenThePageHasAListOfInstructors()
        {
            var fieldSet = Driver.FindElement(By.Id("instructorList"));
            var legend = fieldSet.FindElement(By.TagName("legend"));
            legend.Text.Should().Be.EqualTo("Instructors");

            var list = fieldSet.FindElement(By.TagName("ul"));
            var firstItem = list.FindElements(By.TagName("li")).First();
            var firstItemLink = firstItem.FindElement(By.TagName("a"));
            firstItemLink.Text.Should().Be.EqualTo("Create an instructor");
        }

        [Then(@"I navigate to an instructor detail page")]
        public void ThenINavigateToAnInstructorDetailPage()
        {
            var relativeUrl = "~/Schedule/Instructor/Details/";
            var absoluteUrl = GetAbsoluteUrl(relativeUrl);

            Driver.Url.Should().StartWith(absoluteUrl);

            var instructorIdString = Driver.Url.Remove(0, absoluteUrl.Length);
            Guid instructorId;
            Guid.TryParse(instructorIdString, out instructorId).Should().Be.True();
        }

        [Then(@"the instructor is ""(.*)""")]
        public void ThenTheInstructorIs(string name)
        {
            Driver.Title.Should().Be.EqualTo(name);
        }


    }
}
