namespace Devz.RapidCRUD.Configuration.StatementOptions.Builders
{
    using Devz.RapidCRUD.Configuration.StatementOptions.Builders.Aggregated;

    /// <summary>
    /// Standard sql options builder for a statement.
    /// </summary>
    public interface IStandardSqlStatementOptionsBuilder<TEntity>
        :IStandardSqlStatementOptionsSetter<TEntity,IStandardSqlStatementOptionsBuilder<TEntity>>
    {
    }

    /// <summary>
    /// Standard sql options builder for a statement.
    /// </summary>
    internal class StandardSqlStatementOptionsBuilder<TEntity>
        : AggregatedSqlStatementOptionsBuilder<TEntity, IStandardSqlStatementOptionsBuilder<TEntity>>
        , IStandardSqlStatementOptionsBuilder<TEntity>
    {
        protected override IStandardSqlStatementOptionsBuilder<TEntity> Builder => this;
    }
}
