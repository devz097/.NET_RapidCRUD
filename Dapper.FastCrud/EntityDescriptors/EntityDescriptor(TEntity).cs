﻿namespace Dapper.FastCrud.EntityDescriptors
{
    using System;
    using System.Threading;
    using Dapper.FastCrud.Mappings;
    using Dapper.FastCrud.Mappings.Registrations;
    using Dapper.FastCrud.SqlBuilders;
    using Dapper.FastCrud.SqlStatements;

    /// <summary>
    /// Typed entity descriptor, capable of producing statement builders associated with default entity mappings.
    /// </summary>
    internal class EntityDescriptor<TEntity>:EntityDescriptor
    {
        private readonly Lazy<EntityRegistration> _defaultEntityMapping;

        /// <summary>
        /// Default constructor
        /// </summary>
        public EntityDescriptor()
            :base(typeof(TEntity))
        {
            _defaultEntityMapping = new Lazy<EntityRegistration>(
                ()=> new AutoGeneratedEntityMapping<TEntity>().AutoGeneratedRegistration, 
                LazyThreadSafetyMode.PublicationOnly);
        }

        protected override EntityRegistration DefaultEntityMappingRegistration => _defaultEntityMapping.Value;

        protected override ISqlStatements ConstructSqlStatements(EntityRegistration entityMapping)
        {
            // entityMapping.FreezeMapping();

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
