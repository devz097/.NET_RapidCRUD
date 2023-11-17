namespace Devz.RapidCRUD.Configuration.DialectOptions
{
    internal class MySqlDatabaseOptions : SqlDatabaseOptions
    {
        public MySqlDatabaseOptions()
        {
            this.StartDelimiter = this.EndDelimiter = "`";
        }
    }
}
