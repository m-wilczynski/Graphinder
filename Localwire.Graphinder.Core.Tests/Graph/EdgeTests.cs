namespace Localwire.Graphinder.Core.Tests.Graph
{
    using Core.Graph;
    using Providers;
    using Providers.TestData;
    using Xunit;

    public class EdgeTests
    {
        private readonly ITestDataProvider<Graph> _graphProvider = new TestGraphProvider();

        [Fact]
        public void Edge_Equals_AcceptsInterchangeability()
        {
            var graph = _graphProvider.ProvideValid();
            var node1 = new Node("1", graph);
            var node2 = new Node("2", graph);
            var node3 = new Node("3", graph);

            
        }
    }
}
