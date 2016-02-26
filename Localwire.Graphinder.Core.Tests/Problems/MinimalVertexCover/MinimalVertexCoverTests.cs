namespace Localwire.Graphinder.Core.Tests.Problems.MinimalVertexCover
{
    using Core.Graph;
    using Core.Problems.OptimizationProblems;
    using Providers.TestData;

    public class MinimalVertexCoverTests : IProblemTests
    {
        private readonly TestGraphProvider _structuresFactory = new TestGraphProvider();
        private Graph _validGraph;

        public MinimalVertexCoverTests()
        {
            _validGraph = _structuresFactory.ProvideValid();
            _problem = new MinimalVertexCover();
        }
    }
}
