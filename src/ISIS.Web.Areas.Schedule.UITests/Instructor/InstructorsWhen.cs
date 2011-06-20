using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ISIS.Web.Areas.Schedule.UITests.Instructor
{
    [Binding]
    public class InstructorsWhen : SeleniumFixture
    {

        [When(@"I enter the first name ""(.*)""")]
        public void WhenIEnterTheFirstName(string firstName)
        {
            var firstNameElement = Driver.FindElement(By.Name("FirstName"));
            firstNameElement.SendKeys(firstName);
        }


        [When(@"I enter the last name ""(.*)""")]
        public void WhenIEnterTheLastName(string lastName)
        {
            var lastNameElement = Driver.FindElement(By.Name("LastName"));
            lastNameElement.SendKeys(lastName);
        }




    }
}
