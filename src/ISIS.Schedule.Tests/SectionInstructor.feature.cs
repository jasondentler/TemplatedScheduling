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
namespace ISIS.Schedule
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Section Instructor")]
    public partial class SectionInstructorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SectionInstructor.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Section Instructor", "As a scheduler\nI want to assign instructors to sections", GenerationTargetLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Assign a instructor to a section")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void AssignAInstructorToASection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a instructor to a section", new string[] {
                        "domain"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have set up a new course, template, instructor, and section");
#line 8
 testRunner.When("I assign the instructor to the section");
#line 9
 testRunner.Then("the instructor is assigned to the section");
#line 10
 testRunner.And("it does nothing else");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Unassign a instructor from a section")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void UnassignAInstructorFromASection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Unassign a instructor from a section", new string[] {
                        "domain"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I have set up a new course, template, instructor, and section");
#line 15
 testRunner.And("I have assigned the instructor to the section");
#line 16
 testRunner.When("I unassign the instructor from the section");
#line 17
 testRunner.Then("the instructor is unassigned from the section");
#line 18
 testRunner.And("it does nothing else");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Assign a instructor to a section twice does nothing")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void AssignAInstructorToASectionTwiceDoesNothing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign a instructor to a section twice does nothing", new string[] {
                        "domain"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("I have set up a new course, template, instructor, and section");
#line 23
 testRunner.And("I have assigned the instructor to the section");
#line 24
 testRunner.When("I assign the instructor to the section");
#line 25
 testRunner.Then("it does nothing");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cant assign instructors to a section when the course isnt assigned")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void CantAssignInstructorsToASectionWhenTheCourseIsntAssigned()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cant assign instructors to a section when the course isnt assigned", new string[] {
                        "domain"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("I have set up a new course, template, instructor, and section");
#line 30
 testRunner.And("I have unassigned the course from the instructor");
#line 31
 testRunner.When("I assign the instructor to the section");
#line 32
 testRunner.Then("the aggregate state is invalid");
#line 33
 testRunner.And("the message is \"Your attempt to assign an instructor to this section failed. This" +
                    " instructor isn\'t assigned this course.\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion