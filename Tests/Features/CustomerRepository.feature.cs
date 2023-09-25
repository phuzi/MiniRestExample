// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CustomerRepositoryFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "CustomerRepository.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "CustomerRepository", "Customer repository adding and rereiving customer data\r\n\r\nLink to a feature: [Cal" +
                    "culator](Tests/Features/CustomerRepository.feature)", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CustomerRepository")))
            {
                global::Tests.Features.CustomerRepositoryFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add a customer to the repository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CustomerRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AddACustomer")]
        public virtual void AddACustomerToTheRepository()
        {
            string[] tagsOfScenario = new string[] {
                    "AddACustomer"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a customer to the repository", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table9.AddRow(new string[] {
                            "CustomerRef",
                            "69141d84-f724-4350-b508-8530f54faf42"});
                table9.AddRow(new string[] {
                            "CustomerName",
                            "Major Tom"});
                table9.AddRow(new string[] {
                            "AddressLine1",
                            "Ground Control"});
                table9.AddRow(new string[] {
                            "AddressLine2",
                            ""});
                table9.AddRow(new string[] {
                            "Town",
                            "Some Town"});
                table9.AddRow(new string[] {
                            "County",
                            "Some County"});
                table9.AddRow(new string[] {
                            "Country",
                            "Some Country"});
                table9.AddRow(new string[] {
                            "Postcode",
                            "A1 1AA"});
#line 9
  testRunner.Given("The following customer is added to the repository:", ((string)(null)), table9, "Given ");
#line hidden
#line 19
  testRunner.Then("1 customer will be added to the database context", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table10.AddRow(new string[] {
                            "CustomerRef",
                            "69141d84-f724-4350-b508-8530f54faf42"});
                table10.AddRow(new string[] {
                            "CustomerName",
                            "Major Tom"});
                table10.AddRow(new string[] {
                            "AddressLine1",
                            "Ground Control"});
                table10.AddRow(new string[] {
                            "AddressLine2",
                            ""});
                table10.AddRow(new string[] {
                            "Town",
                            "Some Town"});
                table10.AddRow(new string[] {
                            "County",
                            "Some County"});
                table10.AddRow(new string[] {
                            "Country",
                            "Some Country"});
                table10.AddRow(new string[] {
                            "Postcode",
                            "A1 1AA"});
#line 20
  testRunner.And("The following customer will be added to the database context:", ((string)(null)), table10, "And ");
#line hidden
#line 30
  testRunner.And("The changes are saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Adding a customer passes the cancellation token to the database context")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CustomerRepository")]
        public virtual void AddingACustomerPassesTheCancellationTokenToTheDatabaseContext()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adding a customer passes the cancellation token to the database context", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 33
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 34
  testRunner.Given("A cancellation token is passed when adding a customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 35
  testRunner.And("A customer is added to the repository", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
  testRunner.Then("The cancellation token is passed to AddAsync", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Retrieve a single customer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CustomerRepository")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RetrieveACustomer")]
        public virtual void RetrieveASingleCustomer()
        {
            string[] tagsOfScenario = new string[] {
                    "RetrieveACustomer"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieve a single customer", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 39
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table11.AddRow(new string[] {
                            "CustomerRef",
                            "ede208e7-a176-4c5d-ac7f-b41473048a1e"});
                table11.AddRow(new string[] {
                            "CustomerName",
                            "Name 3"});
                table11.AddRow(new string[] {
                            "AddressLine1",
                            "AddressLine1 3"});
                table11.AddRow(new string[] {
                            "AddressLine2",
                            "AddressLine2 3"});
                table11.AddRow(new string[] {
                            "Town",
                            "Some Town 3"});
                table11.AddRow(new string[] {
                            "County",
                            "Some County 3"});
                table11.AddRow(new string[] {
                            "Country",
                            "Some Country 3"});
                table11.AddRow(new string[] {
                            "Postcode",
                            "A1 1AA 3"});
#line 40
  testRunner.Given("The following customer exists in the database:", ((string)(null)), table11, "Given ");
#line hidden
#line 50
  testRunner.And("A customer with customerRef {ede208e7-a176-4c5d-ac7f-b41473048a1e} is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table12.AddRow(new string[] {
                            "CustomerRef",
                            "ede208e7-a176-4c5d-ac7f-b41473048a1e"});
                table12.AddRow(new string[] {
                            "CustomerName",
                            "Name 3"});
                table12.AddRow(new string[] {
                            "AddressLine1",
                            "AddressLine1 3"});
                table12.AddRow(new string[] {
                            "AddressLine2",
                            "AddressLine2 3"});
                table12.AddRow(new string[] {
                            "Town",
                            "Some Town 3"});
                table12.AddRow(new string[] {
                            "County",
                            "Some County 3"});
                table12.AddRow(new string[] {
                            "Country",
                            "Some Country 3"});
                table12.AddRow(new string[] {
                            "Postcode",
                            "A1 1AA 3"});
#line 51
  testRunner.Then("The following customer is returned:", ((string)(null)), table12, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Attempt to retrieve a non-existant customer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CustomerRepository")]
        public virtual void AttemptToRetrieveANon_ExistantCustomer()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to retrieve a non-existant customer", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 62
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table13.AddRow(new string[] {
                            "CustomerRef",
                            "ede208e7-a176-4c5d-ac7f-b41473048a1e"});
                table13.AddRow(new string[] {
                            "CustomerName",
                            "Name 3"});
                table13.AddRow(new string[] {
                            "AddressLine1",
                            "AddressLine1 3"});
                table13.AddRow(new string[] {
                            "AddressLine2",
                            "AddressLine2 3"});
                table13.AddRow(new string[] {
                            "Town",
                            "Some Town 3"});
                table13.AddRow(new string[] {
                            "County",
                            "Some County 3"});
                table13.AddRow(new string[] {
                            "Country",
                            "Some Country 3"});
                table13.AddRow(new string[] {
                            "Postcode",
                            "A1 1AA 3"});
#line 63
  testRunner.Given("The following customer exists in the database:", ((string)(null)), table13, "Given ");
#line hidden
#line 73
  testRunner.And("A customer with customerRef {3f24b829-1f04-4c36-b2b2-cbcbeb351d69} is requested", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
  testRunner.Then("A null is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Retrieving a customer passes the cancellation token to the database context")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CustomerRepository")]
        public virtual void RetrievingACustomerPassesTheCancellationTokenToTheDatabaseContext()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Retrieving a customer passes the cancellation token to the database context", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 76
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 77
  testRunner.Given("A cancellation token is passed when retrieving a customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 78
  testRunner.And("A customer is requested from the repository", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 79
  testRunner.Then("The cancellation token is passed to FindAsync", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
