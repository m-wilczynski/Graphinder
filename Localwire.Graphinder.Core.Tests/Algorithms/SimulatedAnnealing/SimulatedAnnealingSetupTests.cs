namespace Localwire.Graphinder.Core.Tests.Algorithms.SimulatedAnnealing
{
    using System;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Core.Problems;
    using Graph;
    using NSubstitute;
    using Problems;
    using Providers;
    using Xunit;

    public class SimulatedAnnealingSetupTests
    {
        private readonly ITestDataProvider<CoolingSetup> _coolingSetupProvider = new TestCoolingSetupProvider();
        private readonly TestGraphProvider _dataFactory = new TestGraphProvider();

        private IProblem _problem;
        private CoolingSetup _validCoolingSetup;
        private Graph _validGraph;

        public SimulatedAnnealingSetupTests()
        {
            _problem = Substitute.For<IProblem>();
            _validCoolingSetup = _coolingSetupProvider.ProvideValid();
            _validGraph = _dataFactory.ProvideValid();
        }

        [Fact]
        public void SimulatedAnnealingSetup_ctor_ThrowOnNoGraph()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new SimulatedAnnealingSetup(null, _problem, _validCoolingSetup);
            });
        }

        [Fact]
        public void SimulatedAnnealingSetup_ctor_ThrowOnNoProblem()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new SimulatedAnnealingSetup(_validGraph, null, _validCoolingSetup);
            });
        }

        [Fact]
        public void SimulatedAnnealingSetup_ctor_ThrowOnInvalidCoolingSetup()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new SimulatedAnnealingSetup(_validGraph, _problem, null);
            });
        }
    }
}
