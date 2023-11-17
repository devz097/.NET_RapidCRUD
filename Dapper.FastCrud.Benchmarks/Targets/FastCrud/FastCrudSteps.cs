namespace Devz.RapidCRUD.Benchmarks.Targets.RapidCRUD
{
    using global::Devz.RapidCRUD.Benchmarks.Models;
    using global::Devz.RapidCRUD.Tests.Contexts;
    using NUnit.Framework;
    using System.Collections;
    using System.Linq;
    using System.Reflection;
    using TechTalk.SpecFlow;
    using RapidCRUD = global::Devz.RapidCRUD.DapperExtensions;

    [Binding]
    public class RapidCRUDTests : EntityGenerationSteps
    {
        private readonly DatabaseTestContext _testContext;

        public RapidCRUDTests(DatabaseTestContext testContext)
        {
            _testContext = testContext;
        }

        [BeforeScenario]
        public static void TestSetup()
        {
            // clear caches
            var RapidCRUDCachePropInfo = typeof(OrmConfiguration).GetField("_entityDescriptorCache", BindingFlags.Static | BindingFlags.NonPublic);
            var RapidCRUDCacheInstance = RapidCRUDCachePropInfo.GetValue(null);
            ((IDictionary)RapidCRUDCacheInstance).Clear();
        }

        [When(@"I insert (.*) benchmark entities using Fast Crud")]
        public void WhenIInsertSingleIntKeyEntitiesUsingRapidCRUD(int entitiesCount)
        {
            var dbConnection = _testContext.DatabaseConnection;

            for (var entityIndex = 1; entityIndex <= entitiesCount; entityIndex++)
            {
                var generatedEntity = this.GenerateSimpleBenchmarkEntity(entityIndex);

                RapidCRUD.Insert(dbConnection, generatedEntity);
                // the entity already has the associated id set

                Assert.Greater(generatedEntity.Id, 1); // the seed starts from 2 in the db to avoid confusion with the number of rows modified
                _testContext.RecordInsertedEntity(generatedEntity);
            }
        }

        [Then(@"I should have (.*) benchmark entities in the database")]
        public void ThenIShouldHaveSingleIntKeyEntitiesInTheDatabase(int entitiesCount)
        {
            var dbConnection = _testContext.DatabaseConnection;
            var entities =  RapidCRUD.Find<SimpleBenchmarkEntity>(dbConnection);
            Assert.That(entities.Count(), Is.EqualTo(entitiesCount));
        }

        [When(@"I select all the benchmark entities using Fast Crud (\d+) times")]
        public void WhenISelectAllTheSingleIntKeyEntitiesUsingRapidCRUD(int opCount)
        {
            var dbConnection = _testContext.DatabaseConnection;
            while (--opCount >= 0)
            {
                foreach (var queriedEntity in RapidCRUD.Find<SimpleBenchmarkEntity>(dbConnection))
                {
                    if (opCount == 0)
                    {
                        _testContext.RecordQueriedEntity(queriedEntity);
                    }
                }
            }
        }

        [When(@"I select all the benchmark entities that I previously inserted using Fast Crud")]
        public void WhenISelectAllTheSingleIntKeyEntitiesThatIPreviouslyInsertedUsingRapidCRUD()
        {
            var dbConnection = _testContext.DatabaseConnection;
            foreach (var entity in _testContext.GetInsertedEntitiesOfType<SimpleBenchmarkEntity>())
            {
                _testContext.RecordQueriedEntity(RapidCRUD.Get(dbConnection, new SimpleBenchmarkEntity() {Id = entity.Id}));
            }
        }

        [When(@"I update all the benchmark entities that I previously inserted using Fast Crud")]
        public void WhenIUpdateAllTheSingleIntKeyEntitiesThatIPreviouslyInsertedUsingRapidCRUD()
        {
            var dbConnection = _testContext.DatabaseConnection;

            var entityIndex = 0;
            foreach (var oldEntity in _testContext.GetInsertedEntitiesOfType<SimpleBenchmarkEntity>())
            {
                var newEntity = this.GenerateSimpleBenchmarkEntity(entityIndex++);
                newEntity.Id = oldEntity.Id;
                RapidCRUD.Update(dbConnection, newEntity);
                _testContext.RecordUpdatedEntity(newEntity);
            }
        }

        [When(@"I delete all the inserted benchmark entities using Fast Crud")]
        public void WhenIDeleteAllTheInsertedSingleIntKeyEntitiesUsingRapidCRUD()
        {
            var dbConnection = _testContext.DatabaseConnection;

            foreach (var entity in _testContext.GetInsertedEntitiesOfType<SimpleBenchmarkEntity>())
            {
                RapidCRUD.Delete(dbConnection, entity);
            }
        }
    }
}
