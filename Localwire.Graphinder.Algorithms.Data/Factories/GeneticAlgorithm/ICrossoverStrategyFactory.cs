namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Graph;
    using EnumMappings.StrategyTypes;

    public interface ICrossoverStrategyFactory
    {
        ICrossoverStrategy ProvideOfType(CrossoverStrategyType strategyType, Graph graph);
    }
}
