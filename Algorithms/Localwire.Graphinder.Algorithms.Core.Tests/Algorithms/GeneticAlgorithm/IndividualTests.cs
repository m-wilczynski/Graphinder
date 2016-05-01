namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using System;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Graph;
    using Core.Problems;
    using NSubstitute;
    using NSubstitute.Exceptions;
    using Providers;
    using Providers.SubstituteData;
    using Providers.TestData;
    using Xunit;

    public class IndividualTests
    {
        private readonly ITestDataProvider<Graph> _structuresFactory = new GraphProvider();
        private readonly ISubstituteProvider<IProblem> _problemProvider = new ProblemSubstituteProvider(); 

        private IProblem Problem { get { return _problemProvider.ProvideSubstitute(); } }
        private Graph Graph { get { return _structuresFactory.ProvideValid(); } }

        [Fact]
        public void Individual_ctor_ThrowsOnNoGraph()
        {
            Assert.Throws<ArgumentNullException>(() => new Individual(null, Problem));
        }

        [Fact]
        public void Individual_ctor_ThrowsOnNoProblem()
        {
            Assert.Throws<ArgumentNullException>(() => new Individual(Graph, null));
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
