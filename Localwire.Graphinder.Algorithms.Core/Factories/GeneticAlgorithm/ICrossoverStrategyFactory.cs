namespace Localwire.Graphinder.Core.Factories.GeneticAlgorithm
{
    using Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Algorithms.GeneticAlgorithm.Setup;

    public interface ICrossoverStrategyFactory
    {
        ICrossoverStrategy ProvideOfType(CrossoverStrategyType strategyType);
    }
}
