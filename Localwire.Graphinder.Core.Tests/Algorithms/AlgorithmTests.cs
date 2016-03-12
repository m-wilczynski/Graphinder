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
        protected Algorithm _algorithm;
        protected readonly ISubstituteProvider<IProblem> _problemProvider = new ProblemSubstituteProvider();
        protected readonly ITestDataProvider<Graph> _graphFactory = new TestGraphProvider();

        protected AlgorithmTests()
        { }

        [Fact]
        public void Algorithm_CanAcceptAnswer_ThrowsOnNullAnswer()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _algorithm.CanAcceptAnswer(null);
            });
        }
    }
}
