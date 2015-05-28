﻿namespace Dapper
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading;
    using Dapper.FastCrud;

    /// <summary>
    /// Class for Dapper extensions
    /// </summary>
    public static class DapperExtensions
    {
        private static Dictionary<Type, EntityDescriptor> _entityDescriptorCache = new Dictionary<Type, EntityDescriptor>();
        private static SqlDialect _currentDialect;

        static DapperExtensions()
        {
            Dialect = SqlDialect.MsSql;
        }

        /// <summary>
        /// Queries the database for a single record based on its primary keys.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="connection">Database connection.</param>
        /// <param name="entityKeys">The entity from which the primary keys will be extracted and used for filtering.</param>
        /// <param name="transaction">Transaction to attach the query to.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <returns>Returns a single entity by a single id from table or NULL if none could be found.</returns>
        public static T Get<T>(this IDbConnection connection, T entityKeys, IDbTransaction transaction = null, TimeSpan? commandTimeout = null)
        {
            return GetEntityDescriptor<T>().SingleSelectOperation.Execute(connection, entityKeys, transaction, commandTimeout);
        }

        /// <summary>
        /// Returns all the records in the database.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="connection"></param>
        /// <param name="streamResult">If set to true, the resulting list of entities is not entirely loaded in memory. This is useful for processing large result sets.</param>
        /// <param name="transaction">Transaction to attach the query to.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <returns>Gets a list of all entities</returns>
        public static IEnumerable<T> Get<T>(
            this IDbConnection connection,
            bool streamResult = false,
            IDbTransaction transaction = null,
            TimeSpan? commandTimeout = null)
        {
            return GetEntityDescriptor<T>().BatchSelectOperation.Execute(
                connection,
                streamResults: streamResult,
                transaction: transaction,
                commandTimeout: commandTimeout);
        }

        /// <summary>
        /// Queries the database for a set of records.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="connection"></param>
        /// <param name="queryParameters"></param>
        /// <param name="streamResult">If set to true, the resulting list of entities is not entirely loaded in memory. This is useful for processing large result sets.</param>
        /// <param name="transaction">Transaction to attach the query to.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <param name="whereClause">Where clause (e.g. $"{nameof(User.Name)} = @UserName and {nameof(User.LoggedIn)} = @UserLoggedIn" )</param>
        /// <param name="orderClause">Order clause (e.g. $"{nameof(User.Name)} ASC, {nameof(User.LoggedIn)} DESC" )</param>
        /// <param name="skipRowsCount">Number of rows to skip.</param>
        /// <param name="limitRowsCount">Maximum number of rows to return.</param>
        /// <returns>Gets a list of all entities</returns>
        public static IEnumerable<T> Find<T>(
            this IDbConnection connection,
            FormattableString whereClause = null,
            FormattableString orderClause = null,
            int? skipRowsCount = null,
            int? limitRowsCount = null,
            object queryParameters = null,
            bool streamResult = false, 
            IDbTransaction transaction = null, 
            TimeSpan? commandTimeout = null)
        {
            return GetEntityDescriptor<T>().BatchSelectOperation.Execute(
                connection, 
                whereClause:whereClause,
                orderClause:orderClause,
                skipRowsCount:skipRowsCount,
                limitRowsCount:limitRowsCount,
                queryParameters:queryParameters,
                streamResults:streamResult,
                transaction:transaction,
                commandTimeout:commandTimeout);
        }

        /// <summary>
        /// Inserts an entity into the database.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="entityToInsert"></param>
        /// <param name="transaction">Transaction to attach the query to.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        public static void Insert<T>(this IDbConnection connection, T entityToInsert, IDbTransaction transaction = null, TimeSpan? commandTimeout = null)
        {
            GetEntityDescriptor<T>().SingleInsertOperation.Execute(connection, entityToInsert, transaction: transaction, commandTimeout: commandTimeout);
        }

        /// <summary>
        /// Updates a record in the database.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="entityToUpdate"></param>
        /// <param name="transaction">Transaction to attach the query to.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <param name="properties">
        /// List of properties to include in the update. (e.g. $"{nameof(User.Name)}", "${nameof(User.IsLoggedIn}")
        /// Everything else will be ignored. 
        /// </param>
        /// <returns>True if the item was updated.</returns>
        public static bool UpdatePartial<T>(this IDbConnection connection, T entityToUpdate, IDbTransaction transaction = null, TimeSpan? commandTimeout = null, params FormattableString[] properties)
        {
            return GetEntityDescriptor<T>().SingleUpdateOperation.Execute(connection, entityToUpdate, transaction: transaction, commandTimeout: commandTimeout);
        }


        /// <summary>
        /// Updates a record in the database.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="entityToUpdate"></param>
        /// <param name="transaction">Transaction to attach the query to.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <param name="updatePropertyRestrictions">
        /// List of properties to include in the update. (e.g. $"{nameof(User.Name)}", "${nameof(User.IsLoggedIn}")
        /// Everything else will be ignored. 
        /// </param>
        /// <returns>True if the item was updated.</returns>
        public static bool Update<T>(this IDbConnection connection, T entityToUpdate, IDbTransaction transaction = null, TimeSpan? commandTimeout = null, params FormattableString[] updatePropertyRestrictions)
        {
            return GetEntityDescriptor<T>().SingleUpdateOperation.Execute(connection, entityToUpdate, transaction: transaction, commandTimeout: commandTimeout);
        }

        /// <summary>
        /// Deletes an entity by its primary keys.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="connection"></param>
        /// <param name="entityToDelete"></param>
        /// <param name="transaction">Transaction to attach the query to.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        /// <returns>True if the entity was found and successfully deleted.</returns>
        public static bool Delete<T>(this IDbConnection connection, T entityToDelete, IDbTransaction transaction = null, TimeSpan? commandTimeout = null)
        {
            return GetEntityDescriptor<T>().SingleDeleteOperation.Execute(connection, entityToDelete, transaction: transaction, commandTimeout: commandTimeout);
        }

        /// <summary>
        /// Gets the table name for an entity type
        /// </summary>
        public static string GetTableName<TEntity>(this IDbConnection connection)
        {
            return GetEntityDescriptor<TEntity>().TableName;
        }

        /// <summary>
        /// Gets or sets the dialect
        /// </summary>
        public static SqlDialect Dialect
        {
            get
            {
                return _currentDialect;
            }
            set
            {
                _currentDialect = value;
                Interlocked.Exchange(ref _entityDescriptorCache, new Dictionary<Type, EntityDescriptor>());
            }
        }

        private static EntityDescriptor<TEntity> GetEntityDescriptor<TEntity>()
        {
            var entityType = typeof(TEntity);
            EntityDescriptor<TEntity> entityDescriptor = null;
            EntityDescriptor genericEntityDescriptor;

            if (_entityDescriptorCache.TryGetValue(entityType, out genericEntityDescriptor))
            {
                entityDescriptor = (EntityDescriptor<TEntity>)genericEntityDescriptor;
            }
            else
            {
                entityDescriptor = CreateEntityDescriptor<TEntity>();
            }

            return entityDescriptor;
        }

        private static EntityDescriptor<TEntity> CreateEntityDescriptor<TEntity>()
        {
            EntityDescriptor<TEntity> entityDescriptor;

            switch (_currentDialect)
            {
                case SqlDialect.MsSql:
                    entityDescriptor = new FastCrud.Providers.MsSql.EntityDescriptor<TEntity>();
                    break;
                case SqlDialect.MySql:
                    entityDescriptor = new FastCrud.Providers.MySql.EntityDescriptor<TEntity>();
                    break;
                case SqlDialect.SqLite:
                    entityDescriptor = new FastCrud.Providers.SqLite.EntityDescriptor<TEntity>();
                    break;
                case SqlDialect.PostgreSql:
                    entityDescriptor = new FastCrud.Providers.PostgreSql.EntityDescriptor<TEntity>();
                    break;
                default:
                    throw new InvalidOperationException("Dialect not supported");
            }

            // reads greatly outperform the writes, so a locking mechanism is not required
            var originalDictionary = _entityDescriptorCache;
            Interlocked.Exchange(ref _entityDescriptorCache, new Dictionary<Type, EntityDescriptor>(originalDictionary)
                                                                 {
                                                                     [typeof(TEntity)] = entityDescriptor
                                                                 });

            return entityDescriptor;
        }
    }
}
