using SharpTestsEx;
using TechTalk.SpecFlow;

namespace ISIS.Web.Areas.Schedule.UITests
{
    [Binding]
    public class ISISHomePage_Then : SeleniumFixture
    {

        [Then(@"the page has a link to course scheduling")]
        public void ThenThePageHasALinkToCourseScheduling()
        {
            var link = LinkByText("Course Scheduling");
            link.Should().Not.Be.Null();
        }

        [Then(@"the page has a link to facilities")]
        public void ThenThePageHasALinkToFacilities()
        {
            var link = LinkByText("Facilities");
            link.Should().Not.Be.Null();
        }

    }
}
