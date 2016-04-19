namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using Mappers.EnumMappings.StrategyTypes;

    public interface IMutationStrategyFactory
    {
        IMutationStrategy ProvideOfType(MutationStrategyType strategyType);
    }
}
