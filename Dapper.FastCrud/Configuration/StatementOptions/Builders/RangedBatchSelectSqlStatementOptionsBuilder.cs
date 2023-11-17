namespace Devz.RapidCRUD.Configuration.StatementOptions.Builders
{
    using Devz.RapidCRUD.Configuration.StatementOptions.Builders.Aggregated;

    /// <summary>
    /// Ranged conditional sql options builder for a statement.
    /// </summary>
    public interface IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>
        : IStandardSqlStatementOptionsSetter<TEntity, IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>>,
        IConditionalSqlStatementOptionsOptionsSetter<TEntity, IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>>,
        IRangedConditionalSqlStatementOptionsSetter<TEntity, IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>>,
        IRelationalSqlStatementOptionsSetter<IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>>,
        IParameterizedSqlStatementOptionsSetter<TEntity, IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>>
    {
    }

    /// <summary>
    /// Ranged conditional sql options builder for a statement.
    /// </summary>
    internal class RangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>
        : AggregatedSqlStatementOptionsBuilder<TEntity, IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>>, 
        IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity>
    {
        protected override IRangedBatchSelectSqlSqlStatementOptionsOptionsBuilder<TEntity> Builder => this;
    }
}
