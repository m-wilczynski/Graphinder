namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Mappers.EnumMappings.StrategyTypes;

    internal class SelectionStrategyFactory : ISelectionStrategyFactory
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

        public SelectionStrategyType ProvideMappingType(ISelectionStrategy strategy)
        {
            if (strategy is RouletteStrategy)
                return SelectionStrategyType.RouletteStrategy;
            return SelectionStrategyType.None;
        }
    }
}
