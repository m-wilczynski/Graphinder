namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using EnumMappings.StrategyTypes;

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
