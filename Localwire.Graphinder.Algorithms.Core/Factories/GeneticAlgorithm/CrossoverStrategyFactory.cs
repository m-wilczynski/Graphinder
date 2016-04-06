namespace Localwire.Graphinder.Core.Factories.GeneticAlgorithm
{
    using System;
    using Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Algorithms.GeneticAlgorithm.Setup;
    using Graph;

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
