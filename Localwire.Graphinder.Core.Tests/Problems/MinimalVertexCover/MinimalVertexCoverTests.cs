namespace Localwire.Graphinder.Core.Tests.Problems.MinimalVertexCover
{
    using Algorithms.Providers;
    using Core.Problems.OptimizationProblems;
    using Graph;
    using Xunit;

    public class MinimalVertexCoverTests : IProblemTests
    {
        private readonly DataStructuresFactory _structuresFactory = new DataStructuresFactory();
        private Graph _validGraph;

        public MinimalVertexCoverTests()
        {
            _validGraph = _structuresFactory.ProvideValidGraph();
            _problem = new MinimalVertexCover();
        }
    }
}
