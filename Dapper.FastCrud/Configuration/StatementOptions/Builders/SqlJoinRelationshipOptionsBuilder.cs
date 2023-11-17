namespace Devz.RapidCRUD.Configuration.StatementOptions.Builders
{
    using Devz.RapidCRUD.Configuration.StatementOptions.Builders.Aggregated;

    /// <summary>
    /// SQL statement options builder used in JOINs.
    /// </summary>
    public interface ISqlJoinRelationshipOptionsBuilder<TReferencingEntity, TReferencedEntity>
        : ISqJoinRelationshipOptionsSetter<TReferencingEntity, TReferencedEntity, ISqlJoinRelationshipOptionsBuilder<TReferencingEntity, TReferencedEntity>>
    {
    }

    /// <summary>
    /// SQL statement options builder used in JOIN relationships.
    /// </summary>
    internal class SqlJoinRelationshipOptionsBuilder<TReferencingEntity, TReferencedEntity> 
        : AggregatedSqlStatementJoinRelationshipOptionsBuilder<TReferencingEntity, TReferencedEntity, ISqlJoinRelationshipOptionsBuilder<TReferencingEntity, TReferencedEntity>>,
          ISqlJoinRelationshipOptionsBuilder<TReferencingEntity, TReferencedEntity>
    {
        protected override ISqlJoinRelationshipOptionsBuilder<TReferencingEntity, TReferencedEntity> Builder => this;
    }
}