namespace Localwire.Graphinder.Core.Tests.Algorithms.SimulatedAnnealing
{
    using System;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Graph;
    using NSubstitute;
    using Problems;
    using Providers;
    using Xunit;

    public class SimulatedAnnealingSetupTests
    {
        private readonly SimulatedAnnealingComponentsFactory _componentsFactory = new SimulatedAnnealingComponentsFactory();
        private readonly DataStructuresFactory _dataFactory = new DataStructuresFactory();

        private IProblem _problem;
        private CoolingSetup _validCoolingSetup;
        private Graph _validGraph;

        public SimulatedAnnealingSetupTests()
        {
            _problem = Substitute.For<IProblem>();
            _validCoolingSetup = _componentsFactory.ProvideValidCoolingSetup();
            _validGraph = _dataFactory.ProvideValidGraph();
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
