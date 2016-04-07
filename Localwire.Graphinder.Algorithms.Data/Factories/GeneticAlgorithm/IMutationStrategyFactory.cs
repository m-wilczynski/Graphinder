namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using Core.Algorithms.GeneticAlgorithm.Setup;

    public interface IMutationStrategyFactory
    {
        IMutationStrategy ProvideOfType(MutationStrategyType strategyType);
    }
}
