﻿namespace Dapper.FastCrud.Mappings
{
    using Dapper.FastCrud.Mappings.Registrations;
    using System;
    using System.Threading;

    /// <summary>
    /// Discovers the orm mapping for a particular entity type.
    /// </summary>
    internal class AutoGeneratedEntityMapping<TEntity>
    {
        private readonly Lazy<EntityRegistration> _entityMapping;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AutoGeneratedEntityMapping()
        {
            _entityMapping = new Lazy<EntityRegistration>(this.DiscoverEntityMapping, LazyThreadSafetyMode.PublicationOnly);
        }

        /// <summary>
        /// Returns the auto-generated mapping registration
        /// </summary>
        public EntityRegistration AutoGeneratedRegistration => _entityMapping.Value;

        private EntityRegistration DiscoverEntityMapping()
        {
            var entityType = typeof(TEntity);
            var entityRegistration = new EntityRegistration(entityType);
            var currentConventions = OrmConfiguration.Conventions;

            entityRegistration.TableName = currentConventions.GetTableName(entityType);
            entityRegistration.SchemaName = currentConventions.GetSchemaName(entityType);
            entityRegistration.DatabaseName = currentConventions.GetDatabaseName(entityType);

            foreach (var propDescriptor in currentConventions.GetEntityProperties(entityType))
            {
                var propMapping = entityRegistration.SetProperty(propDescriptor);
                currentConventions.ConfigureEntityPropertyMapping(new PropertyMapping<TEntity>(propMapping));
            }

            return entityRegistration;
        }
    }
}
