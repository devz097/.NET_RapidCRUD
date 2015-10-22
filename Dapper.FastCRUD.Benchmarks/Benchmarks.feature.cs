﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dapper.FastCrud.Benchmarks
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Queries")]
    public partial class QueriesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Benchmarks.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Queries", "", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Insert Benchmark")]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Simple Crud", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Dapper Extensions", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Fast Crud", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Dapper", null)]
        public virtual void InsertBenchmark(string databaseType, string entityType, string entityCount, string microOrm, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Insert Benchmark", exampleTags);
#line 3
this.ScenarioSetup(scenarioInfo);
#line 4
 testRunner.Given(string.Format("I have initialized a {0} database", databaseType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 5
 testRunner.When("I start the stopwatch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 6
 testRunner.And(string.Format("I insert {0} {1} using {2}", entityCount, entityType, microOrm), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.And("I stop the stopwatch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.And(string.Format("I report the stopwatch value for {0} finished processing {1} operations of type i" +
                        "nsert", microOrm, entityCount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.Then(string.Format("I should have {0} {1} in the database", entityCount, entityType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.And(string.Format("I cleanup the {0} database", databaseType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Batch Select No Filter")]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Simple Crud", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Dapper Extensions", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Fast Crud", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Dapper", null)]
        public virtual void BatchSelectNoFilter(string databaseType, string entityType, string entityCount, string microOrm, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Batch Select No Filter", exampleTags);
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.Given(string.Format("I have initialized a {0} database", databaseType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.When(string.Format("I insert {0} {1} using ADO .NET", entityCount, entityType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.And("I refresh the database connection", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I start the stopwatch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And(string.Format("I select all the {0} using {1}", entityType, microOrm), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I clear all the queried entities", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And(string.Format("I select all the {0} using {1}", entityType, microOrm), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("I clear all the queried entities", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And(string.Format("I select all the {0} using {1}", entityType, microOrm), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I stop the stopwatch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And(string.Format("I report the stopwatch value for {0} finished processing 3 operations of type sel" +
                        "ect all", microOrm), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.Then(string.Format("I should have queried {0} entities", entityCount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
 testRunner.And("the queried entities should be the same as the ones I inserted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And(string.Format("I cleanup the {0} database", databaseType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Single Delete Benchmark")]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Simple Crud", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Dapper Extensions", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Fast Crud", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Dapper", null)]
        public virtual void SingleDeleteBenchmark(string databaseType, string entityType, string entityCount, string microOrm, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Single Delete Benchmark", exampleTags);
#line 58
this.ScenarioSetup(scenarioInfo);
#line 59
 testRunner.Given(string.Format("I have initialized a {0} database", databaseType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
 testRunner.When(string.Format("I insert {0} {1} using ADO .NET", entityCount, entityType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
 testRunner.And("I refresh the database connection", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("I start the stopwatch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And(string.Format("I delete all the inserted {0} using {1}", entityType, microOrm), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("I stop the stopwatch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And(string.Format("I report the stopwatch value for {0} finished processing {1} operations of type d" +
                        "elete", microOrm, entityCount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.Then(string.Format("I should have 0 {0} in the database", entityType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
 testRunner.And(string.Format("I cleanup the {0} database", databaseType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Single Select Id Filter Benchmark")]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Simple Crud", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Dapper Extensions", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Fast Crud", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Dapper", null)]
        public virtual void SingleSelectIdFilterBenchmark(string databaseType, string entityType, string entityCount, string microOrm, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Single Select Id Filter Benchmark", exampleTags);
#line 75
this.ScenarioSetup(scenarioInfo);
#line 76
 testRunner.Given(string.Format("I have initialized a {0} database", databaseType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 77
 testRunner.When(string.Format("I insert {0} {1} using ADO .NET", entityCount, entityType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.And("I refresh the database connection", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("I start the stopwatch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And(string.Format("I select all the {0} that I previously inserted using {1}", entityType, microOrm), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("I stop the stopwatch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And(string.Format("I report the stopwatch value for {0} finished processing {1} operations of type s" +
                        "elect by id", microOrm, entityCount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.Then(string.Format("I should have queried {0} entities", entityCount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
 testRunner.And("the queried entities should be the same as the ones I inserted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And(string.Format("I cleanup the {0} database", databaseType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Single Update Benchmark")]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Simple Crud", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Dapper Extensions", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Fast Crud", null)]
        [NUnit.Framework.TestCaseAttribute("LocalDb", "benchmark entities", "30000", "Dapper", null)]
        public virtual void SingleUpdateBenchmark(string databaseType, string entityType, string entityCount, string microOrm, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Single Update Benchmark", exampleTags);
#line 93
this.ScenarioSetup(scenarioInfo);
#line 94
 testRunner.Given(string.Format("I have initialized a {0} database", databaseType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 95
 testRunner.When(string.Format("I insert {0} {1} using ADO .NET", entityCount, entityType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.And("I refresh the database connection", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("I start the stopwatch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And(string.Format("I update all the {0} that I previously inserted using {1}", entityType, microOrm), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I stop the stopwatch", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And(string.Format("I report the stopwatch value for {0} finished processing {1} operations of type u" +
                        "pdate", microOrm, entityCount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And(string.Format("I select all the {0} using Dapper", entityType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.Then("the queried entities should be the same as the ones I updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
 testRunner.Then(string.Format("I cleanup the {0} database", databaseType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
