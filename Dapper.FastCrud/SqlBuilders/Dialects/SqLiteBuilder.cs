﻿namespace Dapper.FastCrud.SqlBuilders.Dialects
{
    using Dapper.FastCrud.EntityDescriptors;
    using Dapper.FastCrud.Mappings.Registrations;
    using System;

    /// <summary>
    /// Statement builder for the <seealso cref="SqlDialect.SqLite"/>.
    /// </summary>
    internal class SqLiteBuilder : GenericStatementSqlBuilder
    {
        public SqLiteBuilder(EntityDescriptor entityDescriptor, EntityRegistration entityMapping)
            : base(entityDescriptor, entityMapping, SqlDialect.SqLite)
        {
        }

        /// <summary>
        /// Constructs a full insert statement
        /// </summary>
        protected override string ConstructFullInsertStatementInternal()
        {
            FormattableString sql = $"INSERT INTO {this.GetTableName()} ({this.ConstructColumnEnumerationForInsert()}) VALUES ({this.ConstructParamEnumerationForInsert()}); ";

            if (this.RefreshOnInsertProperties.Length > 0)
            {
                // we have to bring some column values back
                if (this.InsertKeyDatabaseGeneratedProperties.Length == 1 && this.RefreshOnInsertProperties.Length == 1)
                {
                    // just one, this is going to be easy
                    sql = $"{sql} SELECT last_insert_rowid() as {this.GetDelimitedIdentifier(this.InsertKeyDatabaseGeneratedProperties[0].PropertyName)};";
                }
                else
                {
                    // every table in sqlite has a _ROWID_ column, unless it's been overridden by a user column 
                    sql = $"{sql} SELECT {this.ConstructRefreshOnInsertColumnSelection()} FROM {this.GetTableName()} WHERE {this.GetDelimitedIdentifier("_ROWID_")}=last_insert_rowid();";

                    //// There are no primary keys generated by the database
                    //if (this.InsertKeyDatabaseGeneratedProperties.Length == 0)
                    //{
                    //    sql += $"SELECT {this.ConstructRefreshOnInsertColumnSelection()} FROM {this.GetTableName()} WHERE" + this.ConstructKeysWhereClause();
                    //}
                    //else
                    //{
                    //    sql += this.ResolveWithCultureInvariantFormatter($"SELECT {this.ConstructRefreshOnInsertColumnSelection()} FROM {this.GetTableName()} WHERE {this.GetColumnName(this.InsertKeyDatabaseGeneratedProperties[0], null, false)} = last_insert_rowid();");
                    //}
                }
            }

            return FormattableString.Invariant(sql);
        }

        protected override string ConstructFullSelectStatementInternal(
            string selectClause,
            string fromClause,
            string? whereClause = null,
            string? orderClause = null,
            long? skipRowsCount = null,
            long? limitRowsCount = null)
        {
            FormattableString sql = $"SELECT {selectClause} FROM {fromClause}";

            if (whereClause != null)
            {
                sql = $"{sql} WHERE {whereClause}";
            }

            if (orderClause != null)
            {
                sql = $"{sql} ORDER BY {orderClause}";
            }

            if (limitRowsCount.HasValue || skipRowsCount.HasValue)
            {
                sql = $"{sql} LIMIT {limitRowsCount ?? -1}";
            }

            if (skipRowsCount.HasValue)
            {
                sql = $"{sql} OFFSET {skipRowsCount}";
            }

            return FormattableString.Invariant(sql);
        }
    }
}
