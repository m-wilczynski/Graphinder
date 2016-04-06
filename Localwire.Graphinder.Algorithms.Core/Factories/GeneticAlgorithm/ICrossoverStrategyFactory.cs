namespace Localwire.Graphinder.Core.Factories.GeneticAlgorithm
{
    using Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Algorithms.GeneticAlgorithm.Setup;
    using Graph;

    public interface ICrossoverStrategyFactory
    {
        ICrossoverStrategy ProvideOfType(CrossoverStrategyType strategyType, Graph graph);
    }
}
