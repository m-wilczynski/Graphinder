namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using System;
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using Core.Graph;
    using StrategyTypes;

    class CrossoverStrategyFactory : ICrossoverStrategyFactory
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
    }
}
