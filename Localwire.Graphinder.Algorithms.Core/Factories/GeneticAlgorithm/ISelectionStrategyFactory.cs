namespace Localwire.Graphinder.Core.Factories.GeneticAlgorithm
{
    using Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Algorithms.GeneticAlgorithm.Setup;

    public interface ISelectionStrategyFactory
    {
        ISelectionStrategy ProvideOfType(SelectionStrategyType strategyType);
    }
}
