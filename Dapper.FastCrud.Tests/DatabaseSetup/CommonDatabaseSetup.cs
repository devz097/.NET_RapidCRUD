namespace Devz.RapidCRUD.Tests.DatabaseSetup
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Devz.RapidCRUD.Tests.Models.Poco;
    using Devz.RapidCRUD.Validations;
    using Microsoft.Extensions.Configuration;

    public class CommonDatabaseSetup
    {
        /// <summary>
        /// Retrieves the connection string from the configuration file.
        /// </summary>
        protected string GetConnectionStringFor(IConfiguration configuration, string connectionStringKey)
        {
            Validate.NotNull(configuration, nameof(configuration));

            var connectionString = configuration[$"connectionStrings:add:{connectionStringKey}:connectionString"];
            return connectionString;
        }

        protected void SetupOrmConfiguration(SqlDialect dialect)
        {
            OrmConfiguration.DefaultDialect = dialect;

            // setup any entities that are left via fluent registration
            OrmConfiguration.RegisterEntity<BuildingDbEntity>()
                            .SetTableName("Buildings")
                            .SetProperty(building => building.BuildingId, propMapping => propMapping.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.Identity).SetDatabaseColumnName("Id"))
                            .SetProperty(building => building.Name, propMapping => propMapping.SetDatabaseColumnName("BuildingName"))
                            .SetProperty(building => building.Description) // test mapping w/o name
                            .SetParentChildrenRelationship(
                                building => building.Workstations,
                                workstation => workstation.BuildingId);
        }

    }
}
