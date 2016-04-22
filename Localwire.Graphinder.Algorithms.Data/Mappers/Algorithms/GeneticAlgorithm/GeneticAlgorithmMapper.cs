namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Algorithms.GeneticAlgorithm
{
    using System.Linq;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using Entities.Algorithms.GeneticAlgorithm;
    using Entities.Graph;
    using Factories.GeneticAlgorithm;
    using Graph;
    using Problems;

    internal static class GeneticAlgorithmMapper
    {
        static readonly ISelectionStrategyFactory SelectionFactory = new SelectionStrategyFactory();
        static readonly ICrossoverStrategyFactory CrossoverFactory = new CrossoverStrategyFactory();
        static readonly IMutationStrategyFactory MutationFactory = new MutationStrategyFactory();

        //TODO: Missing current processor time from persistence
        public static GeneticAlgorithm AsDomainModel(this GeneticAlgorithmEntity entity)
        {
            var graph = entity.Graph.AsDomainModel();
            var problem = entity.Problem.AsDomainModelResolved(graph);
            return new GeneticAlgorithm(
                graph, 
                problem,
                new GeneticOperators(
                    SelectionFactory.ProvideOfType(entity.SelectionStrategy),
                    CrossoverFactory.ProvideOfType(entity.CrossoverStrategy, graph),
                    MutationFactory.ProvideOfType(entity.MutationStrategy)),
                new GeneticAlgorithmSettings(entity.GenerationsToCome, entity.InitialPopulationSize,
                    entity.CrossoverProbability, entity.MutationProbability, entity.WithElitistSelection),
                entity.CurrentPopulation.AsDomainModel(graph, problem).ToList(),
                entity.CurrentGeneration,
                entity.Id);
        }

        public static GeneticAlgorithmEntity AsEntityModel(this GeneticAlgorithm model, GraphEntity graph = null)
        {
            var usedGraph = graph ?? model.Graph.AsEntityModel();
            var problem = model.Problem.AsEntityModelResolved(graph);
            return new GeneticAlgorithmEntity
            {
                Id = model.Id,
                Graph = graph,
                Problem = problem,
                SelectionStrategy = SelectionFactory.ProvideMappingType(model.GeneticOperators.SelectionStrategy),
                CrossoverStrategy = CrossoverFactory.ProvideMappingType(model.GeneticOperators.CrossoverStrategy),
                MutationStrategy = MutationFactory.ProvideMappingType(model.GeneticOperators.MutationStrategy),
                GenerationsToCome = model.Settings.GenerationsToCome,
                InitialPopulationSize = model.Settings.InitialPopulationSize,
                CrossoverProbability = model.Settings.CrossoverProbability,
                MutationProbability = model.Settings.MutationProbability,
                WithElitistSelection = model.Settings.WithElitistSelection,
                CurrentPopulation = model.CurrentPopulation.AsEntityModel(graph, problem).ToList(),
                CurrentGeneration = model.CurrentGeneration,
                TotalProcessorTimeCost = model.TotalProcessorTimeCost
            };
        }
    }
}
