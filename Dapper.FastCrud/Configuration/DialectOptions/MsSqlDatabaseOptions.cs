namespace Devz.RapidCRUD.Configuration.DialectOptions
{
    internal class MsSqlDatabaseOptions:SqlDatabaseOptions
    {
        public MsSqlDatabaseOptions()
        {
            this.StartDelimiter = "[";
            this.EndDelimiter = "]";
            this.IsUsingSchemas = true;
        }
    }
}
