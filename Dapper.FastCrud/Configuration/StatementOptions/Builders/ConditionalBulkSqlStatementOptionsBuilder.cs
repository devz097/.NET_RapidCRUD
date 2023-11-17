namespace Devz.RapidCRUD.Configuration.StatementOptions.Builders
{
    using Devz.RapidCRUD.Configuration.StatementOptions.Builders.Aggregated;

    /// <summary>
    /// Conditional sql options builder for statements of type bulk delete/update.
    /// </summary>
    public interface IConditionalBulkSqlStatementOptionsBuilder<TEntity>
        :IStandardSqlStatementOptionsSetter<TEntity, IConditionalBulkSqlStatementOptionsBuilder<TEntity>>,
        IConditionalSqlStatementOptionsOptionsSetter<TEntity, IConditionalBulkSqlStatementOptionsBuilder<TEntity>>,
        IParameterizedSqlStatementOptionsSetter<TEntity, IConditionalBulkSqlStatementOptionsBuilder<TEntity>>
    {
    }

    /// <summary>
    /// Conditional sql options builder for statements of type bulk delete/update.
    /// </summary>
    internal class ConditionalBulkSqlStatementOptionsBuilder<TEntity> 
        : AggregatedSqlStatementOptionsBuilder<TEntity, IConditionalBulkSqlStatementOptionsBuilder<TEntity>> 
        ,IConditionalBulkSqlStatementOptionsBuilder<TEntity>
    {
        protected override IConditionalBulkSqlStatementOptionsBuilder<TEntity> Builder => this;
    }
}
