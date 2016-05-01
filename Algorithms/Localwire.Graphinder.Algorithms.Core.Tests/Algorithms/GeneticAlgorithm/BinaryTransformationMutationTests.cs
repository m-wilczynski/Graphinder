namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using Base;
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using Helpers.Operations.Binary;

    public class BinaryTransformationMutationTests : IMutationStrategyTests
    {
        public BinaryTransformationMutationTests()
        {
            Strategy = new BinaryTransformationStrategy(BinaryTransformationType.RandomBitFlip);
        }
    }
}
