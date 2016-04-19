namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using System;
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Graph;
    using Mappers.EnumMappings.StrategyTypes;

    internal class CrossoverStrategyFactory : ICrossoverStrategyFactory
    {
        public ICrossoverStrategy ProvideOfType(CrossoverStrategyType strategyType, Graph graph)
        {
            if (graph == null)
                throw new ArgumentNullException(nameof(graph));
            switch (strategyType)
            {
                case CrossoverStrategyType.OnePointCrossoverStrategy:
                    return new OnePointCrossoverStrategy(graph);
                case CrossoverStrategyType.None:
                    return null;
                default:
                    return null;
            }
        }

        public CrossoverStrategyType ProvideMappingType(ICrossoverStrategy strategy)
        {
            if (strategy is OnePointCrossoverStrategy)
                return CrossoverStrategyType.OnePointCrossoverStrategy;
            return CrossoverStrategyType.None;
        }
    }
}
