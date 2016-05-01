namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Graph;
    using Mappers.EnumMappings.StrategyTypes;

    public interface ICrossoverStrategyFactory
    {
        ICrossoverStrategy ProvideOfType(CrossoverStrategyType strategyType, Graph graph);
        CrossoverStrategyType ProvideMappingType(ICrossoverStrategy strategy);
    }
}
