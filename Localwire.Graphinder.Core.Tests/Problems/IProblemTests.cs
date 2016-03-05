namespace Localwire.Graphinder.Core.Tests.Problems
{
    using System;
    using System.Collections.Generic;
    using Core.Graph;
    using Core.Problems;
    using Xunit;

    public abstract class IProblemTests
    {
        protected IProblem _problem;

        protected IProblemTests()
        {
        }

        [Fact]
        public void IProblem_Initialize_ThrowOnNullGraph()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _problem.Initialize(null);
            });
        }

        [Fact]
        public void IProblem_AddNewSolution_ThrowOnNullSolution()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _problem.SetNewSolution(null);
            });
        }

        [Fact]
        public void IProblem_IsSolutionCorrect_ThrowOnNullSolution()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                List<Node> invalidParam = null;
                _problem.IsSolutionCorrect(invalidParam);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                bool[] invalidParam = null;
                _problem.IsSolutionCorrect(invalidParam);
            });
        }


    }
}
