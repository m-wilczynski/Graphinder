namespace Localwire.Graphinder.Core.Tests.Algorithms.SimulatedAnnealing
{
    using System;
    using System.Collections.Generic;
    using Core.Algorithms.SimulatedAnnealing;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Core.Graph;
    using Core.Problems;
    using NSubstitute;
    using NSubstitute.Exceptions;
    using Providers;
    using Providers.SubstituteData;
    using Providers.TestData;
    using Xunit;

    public class SimulatedAnnealingTests : AlgorithmTests
    {
        private readonly ITestDataProvider<CoolingSetup> _coolingSetupFactory = new TestCoolingSetupProvider();

        public SimulatedAnnealingTests()
        {
            _algorithm =
                new SimulatedAnnealing(
                    _graphFactory.ProvideValid(),
                    _problemProvider.ProvideSubstitute(),
                    _coolingSetupFactory.ProvideValid());

        }

        [Fact]
        public void SimulatedAnnealing_ctor_ThrowsOnNullGraph()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new SimulatedAnnealing(null,
                    _problemProvider.ProvideSubstitute(),
                    _coolingSetupFactory.ProvideValid());
            });
        }

        [Fact]
        public void SimulatedAnnealing_ctor_ThrowsOnNullProblem()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new SimulatedAnnealing(_graphFactory.ProvideValid(),
                    null,
                    _coolingSetupFactory.ProvideValid());
            });
        }

        [Fact]
        public void SimulatedAnnealing_ctor_ThrowsOnInvalidGraph()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new SimulatedAnnealing(new Graph(), 
                    _problemProvider.ProvideSubstitute(),
                    _coolingSetupFactory.ProvideValid());
            });
        }

        [Fact]
        public void SimulatedAnnealing_ctor_ThrowsOnNullCoolingSetup()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new SimulatedAnnealing(_graphFactory.ProvideValid(),
                    _problemProvider.ProvideSubstitute(),
                    null);
            });
        }

        [Fact]
        public void SimulatedAnnealing_LaunchAlgorithm_UsesCoolingStrategy_Cool()
        {
            _algorithm.LaunchAlgorithm();
            ((SimulatedAnnealing)_algorithm).CoolingSetup.CoolingStrategy.Received().Cool(_algorithm, Arg.Any<Action>());
        }

        [Fact]
        public void SimulatedAnnealing_LaunchAlgorithm_RestartsProblem()
        {
            _algorithm.LaunchAlgorithm();
            _algorithm.Problem.Received().RestartProblemState();
        }

        [Fact]
        public void SimulatedAnnealing_CanAcceptAnswer_ChecksAgainstProblem()
        {
            var solution = new List<Node>();
            _algorithm.CanAcceptAnswer(solution);
            _algorithm.Problem.Received().SolutionOutcome(solution);
        }
    }
}
