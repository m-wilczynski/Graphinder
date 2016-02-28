namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using System;
    using Base;
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Xunit;

    public class RouletteStrategyTests : ISelectionStrategyTests
    {
        public RouletteStrategyTests()
        {
            _strategy = new RouletteStrategy();
        }

        [Fact]
        public void RouletteStrategy_Next_ReturnsProperValueIfOneIndividualPopulation()
        {
            throw new NotImplementedException();
        }
    }
}
