namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using StrategyTypes;

    public interface ISelectionStrategyFactory
    {
        ISelectionStrategy ProvideOfType(SelectionStrategyType strategyType);
    }
}
