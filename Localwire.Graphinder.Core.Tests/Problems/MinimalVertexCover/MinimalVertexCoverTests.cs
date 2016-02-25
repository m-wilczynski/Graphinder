namespace Localwire.Graphinder.Core.Tests.Problems.MinimalVertexCover
{
    using Core.Problems.OptimizationProblems;
    using Graph;
    using Providers.TestData;
    using Xunit;

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
