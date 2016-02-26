namespace Localwire.Graphinder.Core.Tests.Algorithms.SimulatedAnnealing
{
    using System;
    using System.Collections.Generic;
    using Core.Algorithms.SimulatedAnnealing;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Core.Graph;
    using NSubstitute;
    using NSubstitute.Exceptions;
    using Providers;
    using Providers.TestData;
    using Xunit;

    public class SimulatedAnnealingTests : IAlgorithmTests
    {
        private readonly ITestDataProvider<SimulatedAnnealingSetup> _saSetupProvider = new TestSimulatedAnnealingSetupProvider();

        public SimulatedAnnealingTests()
        {
            _algorithm = new SimulatedAnnealing.Builder()
                .WithSetupData(_saSetupProvider.ProvideValid())
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
            builder.WithSetupData(_saSetupProvider.ProvideValid());
            Assert.True(builder.Build() is SimulatedAnnealing);
            //3. Valid setup and 2st proper usage
            builder.WithSetupData(_saSetupProvider.ProvideValid());
            Assert.False(builder.Build() is SimulatedAnnealing);
        }

        [Fact]
        public void SimulatedAnnealing_LaunchAlgorithm_UsesCoolingStrategy_Cool()
        {
            var setup = _saSetupProvider.ProvideValid();
            Assert.Throws<ReceivedCallsException>(() =>
            {
                setup.CoolingSetup.CoolingStrategy
                .Received().Cool(Arg.Any<SimulatedAnnealing>(), Arg.Any<Action>());
            });
            var algorithm = new SimulatedAnnealing.Builder()
                .WithSetupData(setup)
                .Build();
            algorithm.LaunchAlgorithm();
            algorithm.CoolingStrategy.Received().Cool(algorithm, Arg.Any<Action>());
        }

        [Fact]
        public void SimulatedAnnealing_LaunchAlgorithm_RestartsProblem()
        {
            var setup = _saSetupProvider.ProvideValid();
            Assert.Throws<ReceivedCallsException>(() =>
            {
                setup.Problem.Received().RestartProblemState();
            });
            var algorithm = new SimulatedAnnealing.Builder()
                .WithSetupData(setup)
                .Build();
            algorithm.LaunchAlgorithm();
            setup.Problem.Received(2).RestartProblemState();
        }

        [Fact]
        public void SimulatedAnnealing_CanAcceptAnswer_ChecksAgainstProblem()
        {
            var setup = _saSetupProvider.ProvideValid();
            var solution = new List<Node>();
            Assert.Throws<ReceivedCallsException>(() =>
            {
                setup.Problem.Received().SolutionOutcome(solution);
            });
            var algorithm = new SimulatedAnnealing.Builder()
                .WithSetupData(setup)
                .Build();
            algorithm.CanAcceptAnswer(solution);
            setup.Problem.Received().SolutionOutcome(solution);
        }
    }
}
