namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Mappers.EnumMappings.StrategyTypes;

    public interface ISelectionStrategyFactory
    {
        ISelectionStrategy ProvideOfType(SelectionStrategyType strategyType);
    }
}
