﻿namespace Dapper.FastCrud.Tests
{
    using System;
    using System.Linq;
    using Dapper.FastCrud.SqlBuilders;
    using Dapper.FastCrud.Tests.Models;
    using Dapper.FastCrud.Tests.Models.CodeFirst;
    using Dapper.FastCrud.Tests.Models.Poco;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SqlBuilderSteps
    {
        private GenericStatementSqlBuilder _currentSqlBuilder;
        private string _rawSqlStatement;
        private string[] _selectColumnNamesWithDelimiters;
        private SqlDialect _currentDialect;
        private string _buildingRawJoinQueryStatement;


        [Given(@"I extract the SQL builder for LocalDb and workstation")]
        public void GivenIExtractTheSQLBuilderForLocalDbAndWorkstation()
        {
            PrepareEnvironment<Workstation>(SqlDialect.MsSql);
        }

        [Given(@"I extract the SQL builder for PostgreSql and workstation")]
        public void GivenIExtractTheSQLBuilderForPostgreSqlAndWorkstation()
        {
            PrepareEnvironment<Workstation>(SqlDialect.PostgreSql);
        }

        [Given(@"I extract the SQL builder for MySql and workstation")]
        public void GivenIExtractTheSQLBuilderForMySqlAndWorkstation()
        {
            PrepareEnvironment<Workstation>(SqlDialect.MySql);
        }

        [Given(@"I extract the SQL builder for SqLite and workstation")]
        public void GivenIExtractTheSQLBuilderForSqLiteAndWorkstation()
        {
            PrepareEnvironment<Workstation>(SqlDialect.SqLite);
        }

        [When(@"I construct the select column enumeration")]
        public void WhenIConstructTheSelectColumnEnumeration()
        {
            _rawSqlStatement = _currentSqlBuilder.ConstructColumnEnumerationForSelect();
        }

        [Then(@"I should get a valid select column enumeration")]
        public void ThenIShouldGetAValidSelectColumnEnumeration()
        {
            var databaseOptions = OrmConfiguration.Conventions.GetDatabaseOptions(_currentDialect);
            var expectedSql = string.Join(
                ",",
                _selectColumnNamesWithDelimiters.Select(colName => $"{colName}"));
            Assert.That(_rawSqlStatement, Is.EqualTo(expectedSql));
        }

        [When(@"I construct a complex join query for workstation using individual identifier resolvers")]
        public void WhenIConstructAComplexJoinQueryForWorkstationUsingIndividualIdentifierResolvers()
        {
            var parameters = new
                {
                    BuildingName = "Belfry Tower"
                };
            _buildingRawJoinQueryStatement = _currentSqlBuilder.Format(
                $@" SELECT {nameof(Workstation):T}.{nameof(Workstation.WorkstationId):C}, {Sql.Table<Building>()}.{Sql.Column<Building>(nameof(Building.BuildingId))}
                    FROM {nameof(Workstation):T}, {Sql.Table<Building>()}
                    WHERE {nameof(Workstation):T}.{nameof(Workstation.BuildingId):C} = {Sql.Table<Building>()}.{Sql.Column<Building>(nameof(Building.BuildingId))} AND {Sql.Table<Building>()}.{Sql.Column<Building>(nameof(Building.Name))}={Sql.Parameter(nameof(parameters.BuildingName))}" );
        }

        [When(@"I construct a complex join query for workstation using combined table and column identifier resolvers")]
        public void WhenIConstructAComplexJoinQueryForWorkstationUsingCombinedResolvers()
        {
            var parameters = new
                {
                    BuildingName = "Belfry Tower"
                };
            _buildingRawJoinQueryStatement = _currentSqlBuilder.Format(
                $@" SELECT {nameof(Workstation.WorkstationId):TC}, {Sql.TableAndColumn<Building>(nameof(Building.BuildingId))}
                    FROM {nameof(Workstation):T}, {Sql.Table<Building>()}
                    WHERE {nameof(Workstation.BuildingId):TC} = {Sql.TableAndColumn<Building>(nameof(Building.BuildingId))} AND {Sql.Table<Building>()}.{Sql.Column<Building>(nameof(Building.Name))}={Sql.Parameter(nameof(parameters.BuildingName))}");
        }

        [Then(@"I should get a valid join query statement for workstation")]
        public void ThenIShouldGetAValidJoinQueryStatementForWorkstation()
        {
            var parameters = new
                {
                    BuildingName = "Belfry Tower"
                };
            var buildingSqlBuilder = OrmConfiguration.GetSqlBuilder<Building>();
            var expectedQuery =
                $@" SELECT {_currentSqlBuilder.GetTableName()}.{_currentSqlBuilder.GetColumnName(nameof(Workstation.WorkstationId))}, {buildingSqlBuilder.GetTableName()}.{buildingSqlBuilder.GetColumnName(nameof(Building.BuildingId))}
                    FROM {_currentSqlBuilder.GetTableName()}, {buildingSqlBuilder.GetTableName()}
                    WHERE {_currentSqlBuilder.GetTableName()}.{_currentSqlBuilder.GetColumnName(nameof(Workstation.BuildingId))} = {buildingSqlBuilder.GetTableName()}.{buildingSqlBuilder.GetColumnName(nameof(Building.BuildingId))} AND {buildingSqlBuilder.GetTableName()}.{buildingSqlBuilder.GetColumnName(nameof(Building.Name))}=@{nameof(parameters.BuildingName)}";

            Assert.That(_buildingRawJoinQueryStatement, Is.EqualTo(expectedQuery));
        }

        private void PrepareEnvironment<TEntity>(SqlDialect dialect)
        {
            OrmConfiguration.DefaultDialect = dialect;

            // in real library usage, people will use the ISqlBuilder, but for our tests we're gonna need more than that
            _currentSqlBuilder = OrmConfiguration.GetSqlBuilder<TEntity>() as GenericStatementSqlBuilder;
            _currentDialect = dialect;

            var databaseOptions = OrmConfiguration.Conventions.GetDatabaseOptions(_currentDialect);
            _selectColumnNamesWithDelimiters = _currentSqlBuilder.SelectProperties.Select(propInfo =>
            {
                if (propInfo.DatabaseColumnName != propInfo.PropertyName)
                {
                    return $"{databaseOptions.StartDelimiter}{propInfo.DatabaseColumnName}{databaseOptions.EndDelimiter} AS {databaseOptions.StartDelimiter}{propInfo.PropertyName}{databaseOptions.EndDelimiter}";
                }
                
                return $"{databaseOptions.StartDelimiter}{propInfo.PropertyName}{databaseOptions.EndDelimiter}";
            }).ToArray();
        }
    }
}
