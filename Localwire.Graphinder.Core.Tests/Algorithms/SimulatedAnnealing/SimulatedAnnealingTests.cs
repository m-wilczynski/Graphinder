namespace Localwire.Graphinder.Core.Tests.Algorithms.SimulatedAnnealing
{
    using System;
    using System.Collections.Generic;
    using Core.Algorithms.SimulatedAnnealing;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Graph;
    using NSubstitute;
    using Problems;
    using Providers;
    using Xunit;

    public class SimulatedAnnealingTests : IAlgorithmTests
    {
        private readonly ITestDataProvider<SimulatedAnnealingSetup> _saSetupProvider = new TestSimulatedAnnealingSetupProvider();
        private SimulatedAnnealingSetup _setup;

        public SimulatedAnnealingTests()
        {
            _setup = _saSetupProvider.ProvideValid();
            _algorithm = new SimulatedAnnealing.Builder()
                .WithSetupData(_setup)
                .Build();
        }

        [Fact]
        public void SimulatedAnnealing_Builder_ThrowOnNoSetup()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new SimulatedAnnealing.Builder()
                .WithSetupData(null)
                .Build();
            });
        }

        [Fact]
        public void SimulatedAnnealing_Builder_NullIfNotSetup()
        {
            var output = new SimulatedAnnealing.Builder().Build();
            Assert.Equal(null, output);
        }

        [Fact]
        public void SimulatedAnnealing_Builder_UsageOfBuilderAllowedOnlyOnce()
        {
            var builder = new SimulatedAnnealing.Builder();
            //1. No setup and build
            Assert.False(builder.Build() is SimulatedAnnealing);
            //2. Valid setup and 1st proper usage
            builder.WithSetupData(_setup);
            Assert.True(builder.Build() is SimulatedAnnealing);
            //3. Valid setup and 2st proper usage
            builder.WithSetupData(_setup);
            Assert.False(builder.Build() is SimulatedAnnealing);
        }

        [Fact]
        public void SimulatedAnnealing_LaunchAlgorithm_UsesCoolingStrategy_Cool()
        {
            var algorithm = new SimulatedAnnealing.Builder()
                .WithSetupData(_setup)
                .Build();
            algorithm.LaunchAlgorithm();
            algorithm.CoolingStrategy.Received().Cool(algorithm, Arg.Any<Action>());
        }

        [Fact]
        public void SimulatedAnnealing_LaunchAlgorithm_RestartsProblem()
        {
            var algorithm = new SimulatedAnnealing.Builder()
                .WithSetupData(_setup)
                .Build();
            algorithm.LaunchAlgorithm();
            algorithm.Problem.Received().RestartProblemState();
        }

        [Fact]
        public void SimulatedAnnealing_CanAcceptAnswer_ChecksAgainstProblem()
        {
            var algorithm = new SimulatedAnnealing.Builder()
                .WithSetupData(_setup)
                .Build();
            var solution = new List<Node>();
            algorithm.CanAcceptAnswer(solution);
            algorithm.Problem.Received().SolutionOutcome(solution);
        }
    }
}
