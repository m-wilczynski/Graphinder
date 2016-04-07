namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using Core.Graph;

    public interface ICrossoverStrategyFactory
    {
        ICrossoverStrategy ProvideOfType(CrossoverStrategyType strategyType, Graph graph);
    }
}
