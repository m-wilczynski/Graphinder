namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using System;
    using Base;
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Graph;
    using Providers;
    using Providers.TestData;
    using Xunit;

    public class OnePointCrossoverStrategyTests : ICrossoverStrategyTests
    {
        public OnePointCrossoverStrategyTests()
        {
            Strategy = new OnePointCrossoverStrategy(GraphProvider.ProvideValid());
        }

        [Fact]
        public void OnePointCrossoverStrategy_ctor_ThrowOnNullGraph()
        {
            Assert.Throws<ArgumentNullException>(
                () => new OnePointCrossoverStrategy(null));
        }

        [Fact]
        public void OnePointCrossoverStrategy_ctor_ThrowOnInvalidGraph()
        {
            Assert.Throws<ArgumentException>(
                () => new OnePointCrossoverStrategy(new Graph()));
        }
    }
}
