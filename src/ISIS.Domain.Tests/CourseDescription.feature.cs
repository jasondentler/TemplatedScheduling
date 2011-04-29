// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.5.0.0
//      Runtime Version:4.0.30319.225
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace ISIS.Domain.Tests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Course Description")]
    public partial class CourseDescriptionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseDescription.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Course Description", "As a scheduler\nI want to set the course description", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Set the course description")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void SetTheCourseDescription()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Set the course description", new string[] {
                        "domain"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have created a new course");
#line 8
 testRunner.When("I change the course description to \"Description goes here\"");
#line 9
 testRunner.Then("the course description is set to \"Description goes here\"");
#line 10
 testRunner.And("it does nothing else");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Change the course description")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void ChangeTheCourseDescription()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change the course description", new string[] {
                        "domain"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I have created a new course");
#line 15
 testRunner.And("I have changed the course description to \"Description goes here\"");
#line 16
 testRunner.When("I change the course description to \"New description goes here\"");
#line 17
 testRunner.Then("the course description is changed from \"Description goes here\" to \"New descriptio" +
                    "n goes here\"");
#line 18
 testRunner.And("it does nothing else");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Change the course description to the same thing")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void ChangeTheCourseDescriptionToTheSameThing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change the course description to the same thing", new string[] {
                        "domain"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I have created a new course");
#line 23
 testRunner.And("I have changed the course description to \"Description goes here\"");
#line 24
 testRunner.When("I change the course description to \"Description goes here\"");
#line 25
 testRunner.Then("it does nothing");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
