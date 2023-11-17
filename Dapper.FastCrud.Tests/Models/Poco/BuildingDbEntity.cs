namespace Devz.RapidCRUD.Tests.Models.Poco
{
    using System.Collections.Generic;
    using Devz.RapidCRUD.Tests.DatabaseSetup;
    using Devz.RapidCRUD.Tests.Models.CodeFirst;

    /// <summary>
    /// Entity used for POCO tests.
    /// A fluent style registration is being used for the mappings inside <see cref="CommonDatabaseSetup.SetupOrmConfiguration"/>.
    /// </summary>
    public class BuildingDbEntity
    {
        public int? BuildingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<WorkstationDbEntity> Workstations { get; set; }
    }
}
