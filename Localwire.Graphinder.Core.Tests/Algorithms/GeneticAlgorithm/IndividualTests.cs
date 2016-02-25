namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using System;
    using System.Collections.Generic;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Problems;
    using Graph;
    using NSubstitute;
    using NSubstitute.ExceptionExtensions;
    using NSubstitute.Exceptions;
    using Providers.TestData;
    using Tests.Providers;
    using Tests.Providers.SubstituteData;
    using Xunit;

    public class IndividualTests
    {
        private readonly ITestDataProvider<Graph> _structuresFactory = new TestGraphProvider();
        private readonly ISubstituteProvider<IProblem> _problemProvider = new ProblemSubstituteProvider(); 

        private IProblem Problem { get { return _problemProvider.ProvideSubstitute(); } }
        private Graph Graph { get { return _structuresFactory.ProvideValid(); } }

        [Fact]
        public void Individual_ctor_ThrowsOnNoGraph()
        {
            Assert.Throws<ArgumentException>(() => new Individual(null, Problem));
        }

        [Fact]
        public void Individual_ctor_ThrowsOnNoProblem()
        {
            Assert.Throws<ArgumentException>(() => new Individual(Graph, null));
        }

        [Fact]
        public void Individual_ctor_EnsuresCorrectnessAgainstProblem()
        {
            var problem = Problem;
            Assert.Throws<ReceivedCallsException>(() =>
            {
                problem.Received().IsSolutionCorrect(Arg.Any<bool[]>());
            });

            new Individual(Graph, problem);
            problem.Received().IsSolutionCorrect(Arg.Any<bool[]>());
        }

    }
}
