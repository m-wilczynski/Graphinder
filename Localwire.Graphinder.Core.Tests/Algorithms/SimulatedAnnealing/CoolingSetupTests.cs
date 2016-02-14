namespace Localwire.Graphinder.Core.Tests.Algorithms.SimulatedAnnealing
{
    using System;
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using NSubstitute;
    using Xunit;

    public class CoolingSetupTests
    {
        private ICoolingStrategy _strategy;
        private int _validInitialTemperature = 100;
        private int _invalidInitialTemperature = -5;
        private double _validCoolingRatio = 0.1;
        private double _invalidCoolingRatio = -1.5;

        public CoolingSetupTests()
        {
            _strategy = Substitute.For<ICoolingStrategy>();
        }

        [Fact]
        public void CoolingSetup_ctor_ThrowOnInvalidInitialTemperature()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new CoolingSetup(_invalidInitialTemperature, _validCoolingRatio, _strategy);
            });
        }

        [Fact]
        public void CoolingSetup_ctor_ThrowOnInvalidCoolingRatio()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new CoolingSetup(_validInitialTemperature, _invalidCoolingRatio, _strategy);
            });
        }

        [Fact]
        public void CoolingSetup_ctor_ThrowOnNoStrategy()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new CoolingSetup(_validInitialTemperature, _validCoolingRatio, null);
            });
        }

    }
}
