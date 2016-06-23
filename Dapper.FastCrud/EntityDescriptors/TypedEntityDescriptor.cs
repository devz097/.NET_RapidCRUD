﻿namespace Dapper.FastCrud.EntityDescriptors
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Dapper.FastCrud.Mappings;
    using Dapper.FastCrud.SqlBuilders;
    using Dapper.FastCrud.SqlStatements;

    /// <summary>
    /// Typed entity descriptor, capable of producing statement builders associated with default entity mappings.
    /// </summary>
    internal class EntityDescriptor<TEntity>:EntityDescriptor
    {
        // entity mappings should have a very long timespan if used correctly, however we can't make that assumption
        // hence we'll have to keep them for the duration of their lifespan and attach precomputed sql statements
        private readonly ConditionalWeakTable<EntityMapping, ISqlStatements> _registeredEntityMappings;
        private readonly Lazy<ISqlStatements> _defaultEntityMappingSqlStatements;

        /// <summary>
        /// Default constructor
        /// </summary>
        public EntityDescriptor()
            :base(typeof(TEntity))
        {
            this.DefaultEntityMapping = new AutoGeneratedEntityMapping<TEntity>();
            _defaultEntityMappingSqlStatements = new Lazy<ISqlStatements>(()=>this.ConstructSqlStatements(this.DefaultEntityMapping), LazyThreadSafetyMode.PublicationOnly);
            _registeredEntityMappings = new ConditionalWeakTable<EntityMapping, ISqlStatements>();
        }

        /// <summary>
        /// Returns the sql statements for an entity mapping, or the default one if the argument is null.
        /// </summary>
        public ISqlStatements GetSqlStatements(EntityMapping entityMapping = null)
        {
            ISqlStatements sqlStatements;
            // default entity mappings are the ones that are mostly used, treat them differently
            if (entityMapping == null)
            {
                sqlStatements = _defaultEntityMappingSqlStatements.Value;
            }
            else
            {
                sqlStatements = _registeredEntityMappings.GetValue(entityMapping, mapping => this.ConstructSqlStatements(mapping));
            }

            return sqlStatements;
        }

        private ISqlStatements ConstructSqlStatements(EntityMapping entityMapping)
        {
            entityMapping.FreezeMapping();

            ISqlStatements sqlStatements;
            GenericStatementSqlBuilder statementSqlBuilder;

            switch (entityMapping.Dialect)
            {
                case SqlDialect.MsSql:
                    statementSqlBuilder = new MsSqlBuilder(this, entityMapping);
                    break;
                case SqlDialect.MySql:
                    statementSqlBuilder = new MySqlBuilder(this, entityMapping);
                    break;
                case SqlDialect.PostgreSql:
                    statementSqlBuilder = new PostgreSqlBuilder(this, entityMapping);
                    break;
                case SqlDialect.SqLite:
                    statementSqlBuilder = new SqLiteBuilder(this, entityMapping);
                    break;
                default:
                    throw new NotSupportedException($"Dialect {entityMapping.Dialect} is not supported");
            }

            sqlStatements = new GenericSqlStatements<TEntity>(statementSqlBuilder);
            return sqlStatements;
        }
    }
}