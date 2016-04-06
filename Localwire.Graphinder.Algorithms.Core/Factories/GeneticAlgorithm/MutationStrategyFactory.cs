namespace Localwire.Graphinder.Core.Factories.GeneticAlgorithm
{
    using Algorithms.GeneticAlgorithm.MutationStrategies;
    using Algorithms.GeneticAlgorithm.Setup;

    class MutationStrategyFactory : IMutationStrategyFactory
    {
        public IMutationStrategy ProvideOfType(MutationStrategyType strategyType)
        {
            switch (strategyType)
            {
                case MutationStrategyType.BinaryTransformationStrategy:
                    return new BinaryTransformationStrategy();
                case MutationStrategyType.None:
                    return null;
                default:
                    return null;
            }
        }
    }
}
