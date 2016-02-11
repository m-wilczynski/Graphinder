namespace Localwire.Graphinder.Core.Tests.Algorithms.SimulatedAnnealing
{
    using System;
    using Core.Algorithms.SimulatedAnnealing;
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Graph;
    using NSubstitute;
    using Problems;
    using Xunit;

    public class AllRandomCoolingTests
    {
        private ICoolingStrategy _strategy;
        private SimulatedAnnealing _simulatedAnnealing;

        public AllRandomCoolingTests()
        {
            _strategy = new AllRandomCooling();
            
        }

        [Fact]
        public void AllRandomCooling_Cool_ThrowOnNoAlgorithm()
        {
            //Assert.Throws<ArgumentException>(() => _strategy.Cool(null, () => { }));
        }

        [Fact]
        public void AllRandomCooling_Cool_ThrowOnNoCoolAction()
        {
            //Assert.Throws<ArgumentException>(() => _strategy.Cool(_simulatedAnnealing, () => { }));
        }

        [Fact]
        public void AllRandomCooling_Cool_ExecutesCorrectly()
        {
            
        }
    }
}
