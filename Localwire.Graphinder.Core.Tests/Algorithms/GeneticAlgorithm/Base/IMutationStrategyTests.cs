namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm.Base
{
    using System;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using Providers;
    using Providers.TestData;
    using Xunit;

    public abstract class IMutationStrategyTests
    {
        protected IMutationStrategy _strategy;
        protected ITestDataProvider<Individual> _individualProvider; 

        protected IMutationStrategyTests()
        {
            _individualProvider = new TestIndividualProvider();
        }

        [Fact]
        public void IMutationStrategy_Mutate_ThrowsOnNullIndividual()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _strategy.Mutate(null);
            });

            _strategy.Mutate(_individualProvider.ProvideValid());
        }
    }
}
