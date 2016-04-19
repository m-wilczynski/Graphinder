namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Algorithms.GeneticAlgorithm
{
    using System.Linq;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using Entities.Algorithms.GeneticAlgorithm;
    using Factories.GeneticAlgorithm;
    using Graph;
    using Problems;

    internal static class GeneticAlgorithmMapper
    {
        static readonly ISelectionStrategyFactory SelectionFactory = new SelectionStrategyFactory();
        static readonly ICrossoverStrategyFactory CrossoverFactory = new CrossoverStrategyFactory();
        static readonly IMutationStrategyFactory MutationFactory = new MutationStrategyFactory();

        public static GeneticAlgorithm AsDomainModel(this GeneticAlgorithmEntity entity)
        {
            var graph = entity.Graph.AsDomainModel();
            return new GeneticAlgorithm(
                graph, 
                entity.Problem.AsDomainModelResolved(),
                new GeneticOperators(
                    SelectionFactory.ProvideOfType(entity.SelectionStrategy),
                    CrossoverFactory.ProvideOfType(entity.CrossoverStrategy, graph),
                    MutationFactory.ProvideOfType(entity.MutationStrategy)),
                new GeneticAlgorithmSettings(entity.GenerationsToCome, entity.InitialPopulationSize,
                    entity.CrossoverProbability, entity.MutationProbability, entity.WithElitistSelection),
                entity.CurrentPopulation.AsDomainModel().ToList(),
                entity.CurrentGeneration,
                entity.Id);
        }

        public static GeneticAlgorithmEntity AsEntityModel(this GeneticAlgorithm model)
        {
            return new GeneticAlgorithmEntity
            {
                Id = model.Id,
                Graph = model.Graph.AsEntityModel(),
                Problem = model.Problem.AsEntityModelResolved(),
                SelectionStrategy = SelectionFactory.ProvideMappingType(model.GeneticOperators.SelectionStrategy),
                CrossoverStrategy = CrossoverFactory.ProvideMappingType(model.GeneticOperators.CrossoverStrategy),
                MutationStrategy = MutationFactory.ProvideMappingType(model.GeneticOperators.MutationStrategy),
                GenerationsToCome = model.Settings.GenerationsToCome,
                InitialPopulationSize = model.Settings.InitialPopulationSize,
                CrossoverProbability = model.Settings.CrossoverProbability,
                MutationProbability = model.Settings.MutationProbability,
                WithElitistSelection = model.Settings.WithElitistSelection,
                CurrentPopulation = model.CurrentPopulation.AsEntityModel().ToList(),
                CurrentGeneration = model.CurrentGeneration
            };
        }
    }
}
