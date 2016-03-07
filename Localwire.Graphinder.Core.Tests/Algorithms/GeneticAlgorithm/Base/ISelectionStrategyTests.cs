namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm.Base
{
    using System;
    using System.Collections.Generic;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Providers;
    using Providers.TestData;
    using Xunit;

    public abstract class ISelectionStrategyTests
    {
        protected ISelectionStrategy _strategy;
        private readonly ITestDataProvider<Individual> _individualProvider = new TestIndividualProvider();

        protected ISelectionStrategyTests()
        {
        }

        [Fact]
        public void ISelectionStrategy_Set_ThrowsOnNullPopulation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _strategy.Set(null);
            });

            _strategy.Set(new List<Individual>());
        }

        [Fact]
        public void ISelectionStrategy_Next_ThrowsOnEmptyPopulation()
        {
            _strategy.Set(new List<Individual>());
            Assert.Throws<InvalidOperationException>(() =>
            {
                _strategy.Next();
            });
        }

        [Fact]
        public void ISelectionStrategy_Next_ReturnsValid()
        {
            var individuals = new List<Individual>
            {
                _individualProvider.ProvideValid(),
                _individualProvider.ProvideValid(),
                _individualProvider.ProvideValid()
            };
            _strategy.Set(individuals);
            Assert.Contains(individuals, i => i.Equals(_strategy.Next()));
        }

        [Fact]
        public void ISelectionStrategy_Next_ReturnsProperValueIfOneIndividualPopulation()
        {
            var individuals = new List<Individual> {_individualProvider.ProvideValid()};
            _strategy.Set(individuals);
            Assert.Contains(individuals, i => i.Equals(_strategy.Next()));
        }

        [Fact]
        public void ISelectionStrategy_NextCouple_ReturnsValid()
        {
            var individuals = new List<Individual>
            {
                _individualProvider.ProvideValid(),
                _individualProvider.ProvideValid(),
                _individualProvider.ProvideValid()
            };
            _strategy.Set(individuals);
            var couple = _strategy.NextCouple();
            Assert.Contains(individuals, i => i.Equals(couple.Item1));
            Assert.Contains(individuals, i => i.Equals(couple.Item2));
            Assert.NotEqual(couple.Item1, couple.Item2);
        }

        [Fact]
        public void ISelectionStrategy_NextCouple_ThrowOnPopulationLessThanTwo()
        {
            var individuals = new List<Individual> { _individualProvider.ProvideValid() };
            _strategy.Set(individuals);
            Assert.Throws<InvalidOperationException>(() => _strategy.NextCouple());
        }

    }
}
