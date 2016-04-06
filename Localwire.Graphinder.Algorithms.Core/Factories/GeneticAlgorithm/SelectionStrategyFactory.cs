namespace Localwire.Graphinder.Core.Factories.GeneticAlgorithm
{
    using Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Algorithms.GeneticAlgorithm.Setup;

    public class SelectionStrategyFactory : ISelectionStrategyFactory
    {
        public ISelectionStrategy ProvideOfType(SelectionStrategyType strategyType)
        {
            switch (strategyType)
            {
                case SelectionStrategyType.RouletteStrategy:
                    return new RouletteStrategy();
                case SelectionStrategyType.None:
                    return null;
                default:
                    return null;
            }
        }
    }
}
