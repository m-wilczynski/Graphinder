namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm.Base
{
    using System;
    using System.Collections.Generic;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Xunit;

    public abstract class ISelectionStrategyTests
    {
        protected ISelectionStrategy _strategy;

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
    }
}
