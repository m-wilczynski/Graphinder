namespace Localwire.Graphinder.Core.Tests.Algorithms.SimulatedAnnealing
{
    using System;
    using Core.Algorithms;
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using NSubstitute;
    using Xunit;

    public class AllRandomCoolingTests
    {
        private readonly ICoolingStrategy _strategy;
        private readonly IAlgorithm _algorithm;

        public AllRandomCoolingTests()
        {
            _strategy = new AllRandomCooling();
            _algorithm = Substitute.For<IAlgorithm>();
        }

        [Fact]
        public void AllRandomCooling_Cool_ThrowOnNoAlgorithm()
        {
            Assert.Throws<ArgumentException>(() => _strategy.Cool(null, () => { }));
        }

        [Fact]
        public void AllRandomCooling_Cool_ThrowOnNoCoolAction()
        {
            Assert.Throws<ArgumentException>(() => _strategy.Cool(_algorithm, null));
        }

        [Fact]
        public void AllRandomCooling_Cool_ExecutesCorrectly()
        {
            _strategy.Cool(_algorithm, () => { });
        }
    }
}
