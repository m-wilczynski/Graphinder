namespace Localwire.Graphinder.Core.Factories
{
    using Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Algorithms.GeneticAlgorithm.Setup;

    public interface ISelectionStrategyFactory
    {
        ISelectionStrategy ProvideOfType(SelectionStrategyType strategyType);
    }
}
