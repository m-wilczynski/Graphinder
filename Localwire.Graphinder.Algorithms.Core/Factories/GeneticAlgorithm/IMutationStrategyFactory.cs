namespace Localwire.Graphinder.Core.Factories.GeneticAlgorithm
{
    using Algorithms.GeneticAlgorithm.MutationStrategies;
    using Algorithms.GeneticAlgorithm.Setup;

    public interface IMutationStrategyFactory
    {
        IMutationStrategy ProvideOfType(MutationStrategyType strategyType);
    }
}
