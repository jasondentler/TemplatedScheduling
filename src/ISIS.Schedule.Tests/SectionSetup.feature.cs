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
    [NUnit.Framework.DescriptionAttribute("Section setup")]
    public partial class SectionSetupFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SectionSetup.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Section setup", "As a scheduler or department chair\nI want to create sections from templates", GenerationTargetLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Create a section from a template")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void CreateASectionFromATemplate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a section from a template", new string[] {
                        "domain"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have set up a course and template");
#line 8
 testRunner.And("I have activated the template");
#line 9
 testRunner.When("I create a section 01 from the template");
#line 10
 testRunner.Then("section 01 is created");
#line 11
 testRunner.And("the section data matches the basic template data");
#line 12
 testRunner.And("it does nothing else");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cant create a section from a non-active template")]
        [NUnit.Framework.CategoryAttribute("domain")]
        public virtual void CantCreateASectionFromANon_ActiveTemplate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cant create a section from a non-active template", new string[] {
                        "domain"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I have set up a course and template");
#line 17
 testRunner.And("I have made the template pending");
#line 18
 testRunner.When("I create a section 01 from the template");
#line 19
 testRunner.Then("the aggregate state is invalid");
#line 20
 testRunner.And("the message is \"Your attempt to create a section failed. The template is not acti" +
                    "ve.\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
