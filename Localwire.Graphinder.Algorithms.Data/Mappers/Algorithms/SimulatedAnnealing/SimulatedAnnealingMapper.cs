namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Algorithms.SimulatedAnnealing
{
    using System.Runtime.InteropServices;
    using Core.Algorithms.SimulatedAnnealing;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Entities.Algorithms.SimulatedAnnealing;
    using Factories.SimulatedAnnealing;
    using Graph;
    using Problems;

    internal static class SimulatedAnnealingMapper
    {
        static readonly ICoolingStrategyFactory CoolingFactory = new CoolingStrategyFactory();

        //TODO: Missing current processor time from persistence
        public static SimulatedAnnealing AsDomainModel(this SimulatedAnnealingEntity entity)
        {
            var graph = entity.Graph.AsDomainModel();
            var problem = entity.Problem.AsDomainModelResolved();
            return new SimulatedAnnealing(graph, problem,
                new CoolingSetup(entity.InitialTemperature, entity.CoolingRate,
                    CoolingFactory.ProvideOfType(entity.CoolingStrategy)),
                entity.CurrentTemperature,
                entity.Id);
        }

        public static SimulatedAnnealingEntity AsEntityModel(this SimulatedAnnealing model)
        {
            var graph = model.Graph.AsEntityModel();
            var problem = model.Problem.AsEntityModelResolved();
            return new SimulatedAnnealingEntity
            {
                Id = model.Id,
                Graph = graph,
                CoolingRate = model.CoolingSetup.CoolingRate,
                CoolingStrategy = CoolingFactory.ProvideMappingType(model.CoolingSetup.CoolingStrategy),
                CurrentTemperature = model.CurrentTemperature,
                InitialTemperature = model.CoolingSetup.InitialTemperature,
                Problem = problem,
                TotalProcessorTimeCost = model.TotalProcessorTimeCost
            };
        }
    }
}
