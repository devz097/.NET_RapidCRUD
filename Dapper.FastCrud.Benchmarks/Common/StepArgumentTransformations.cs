namespace Devz.RapidCRUD.Benchmarks.Common
{
    using System;
    using Devz.RapidCRUD.Benchmarks.Models;
    using TechTalk.SpecFlow;

    [Binding]
    internal class StepArgumentTransformations
    {
        [StepArgumentTransformation("benchmark")]
        public Type WorkstationEntityToType()
        {
            return typeof(SimpleBenchmarkEntity);
        }
    }
}
