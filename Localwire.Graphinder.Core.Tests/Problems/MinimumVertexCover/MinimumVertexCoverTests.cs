namespace Localwire.Graphinder.Core.Tests.Problems.MinimumVertexCover
{
    using Core.Graph;
    using Core.Problems.OptimizationProblems;
    using Providers.TestData;

    public class MinimumVertexCoverTests : IProblemTests
    {
        private readonly GraphProvider _structuresFactory = new GraphProvider();
        private Graph _validGraph;

        public MinimumVertexCoverTests()
        {
            _validGraph = _structuresFactory.ProvideValid();
            _problem = new MinimumVertexCover();
        }
    }
}
