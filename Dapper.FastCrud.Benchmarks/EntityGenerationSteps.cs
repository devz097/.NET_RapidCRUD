namespace Devz.RapidCRUD.Benchmarks
{
    using Devz.RapidCRUD.Benchmarks.Models;
    using System;
    using System.Data.SqlTypes;
    using Devz.RapidCRUD.Tests.Models;

    public class EntityGenerationSteps
    {
        protected SimpleBenchmarkEntity GenerateSimpleBenchmarkEntity(int entityIndex, SimpleBenchmarkEntity entity = null)
        {
            if (entity == null)
            {
                entity = new SimpleBenchmarkEntity();
            }

            entity.FirstName = $"First Name {entityIndex}";
            entity.LastName = $"Last Name {entityIndex}";
            entity.DateOfBirth = new SqlDateTime(DateTime.Now).Value;

            return entity;
        }
    }
}
