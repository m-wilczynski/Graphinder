namespace Localwire.Graphinder.Core.Tests.Algorithms
{
    using System;
    using Core.Algorithms;
    using Core.Graph;
    using Core.Problems;
    using Providers;
    using Providers.SubstituteData;
    using Providers.TestData;
    using Xunit;

    public abstract class AlgorithmTests
    {
        protected Algorithm Algorithm;
        protected readonly ISubstituteProvider<IProblem> _problemProvider = new ProblemSubstituteProvider();
        protected readonly ITestDataProvider<Graph> _graphFactory = new GraphProvider();

        protected AlgorithmTests()
        { }

        [Fact]
        public void Algorithm_CanAcceptAnswer_ThrowsOnNullAnswer()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Algorithm.CanAcceptAnswer(null);
            });
        }

        [Fact]
        public void Algorithm_LaunchSolution_LocksGraph()
        {
            Algorithm.LaunchAlgorithm();
            Assert.False(Algorithm.Graph.CanAdd());
        }

        protected void BlockTestExecutionUntilLaunchAlgorithmFinishes(IAlgorithm algorithm)
        {
            while (algorithm.CanContinueSearching())
            { }
        }
    }
}
