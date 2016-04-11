namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using EnumMappings.StrategyTypes;

    public interface IMutationStrategyFactory
    {
        IMutationStrategy ProvideOfType(MutationStrategyType strategyType);
    }
}
