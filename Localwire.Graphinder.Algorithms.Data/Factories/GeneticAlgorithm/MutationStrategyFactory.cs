namespace Localwire.Graphinder.Algorithms.DataAccess.Factories.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using Mappers.EnumMappings.StrategyTypes;

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
