namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using Base;
    using Core.Algorithms.SelectionStrategies;

    public class RouletteStrategyTests : ISelectionStrategyTests
    {
        public RouletteStrategyTests()
        {
            _strategy = new RouletteStrategy();
        }
    }
}
