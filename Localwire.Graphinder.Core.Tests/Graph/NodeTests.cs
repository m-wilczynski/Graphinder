namespace Localwire.Graphinder.Core.Tests.Graph
{
    using System;
    using Core.Graph;
    using Providers;
    using Providers.TestData;
    using Xunit;

    public class NodeTests
    {
        private readonly ITestDataProvider<Graph> _graphProvider = new TestGraphProvider();
        private readonly Graph _graph;
        private Node _validNode, _validNeighbour;

        public NodeTests()
        {
            _graph = _graphProvider.ProvideValid();
            _validNode = _graph.AddNode("1");
            _validNeighbour = _graph.AddNode("2");
        }

        [Fact]
        public void Node_ctor_ThrowOnEmptyOrNullKey()
        {
            Assert.Throws<ArgumentException>(() => new Node(null, _graph));
            Assert.Throws<ArgumentException>(() => new Node("", _graph));
        }

        [Fact]
        public void Node_ctor_ThrowOnNullParent()
        {
            Assert.Throws<ArgumentNullException>(() => new Node("1", null));
        }

        [Fact]
        public void Node_Equals_AcceptsValid()
        {
            Assert.Equal(_validNode, _validNode);
        }

        [Fact]
        public void Node_Equals_FalseOnGraphMismatch()
        {
            Assert.NotEqual(_validNode, new Node("1", _graphProvider.ProvideValid()));
        }

        [Fact]
        public void Node_Equals_FalseOnKeyMismatch()
        {
            Assert.NotEqual(_validNode, new Node("2", _graph));
        }

        [Fact]
        public void Node_AddNeighbour_ThrowOnNullNeighbour()
        {
            Assert.Throws<ArgumentNullException>(() => _validNode.AddNeighbour(null));
        }

        [Fact]
        public void Node_AddNeighbour_ThrowOnAttemptToAddYourself()
        {
            Assert.Throws<InvalidOperationException>(() => _validNode.AddNeighbour(_validNode));
        }

        [Fact]
        public void Node_AddNeighbour_ThrowInvalidOperationIfNotPerformedByGraph()
        {
            //Perfectly valid Node but missing Edge in Graph will make it fail
            Assert.Throws<InvalidOperationException>(() =>
            {
                _validNode.AddNeighbour(_graph.AddNode(Guid.NewGuid().ToString()));
            });
        }

        [Fact]
        public void Node_RemoveNeighbour_ThrowOnNullNeighbour()
        {
            Assert.Throws<ArgumentNullException>(() => _validNode.RemoveNeighbour(null));
        }

        [Fact]
        public void Node_RemoveNeighbour_ThrowIfNotPerformedByGraph()
        {
            //Perfectly valid operation except, it's not performed via Graph, so it'll fail
            _graph.AddEdge(_validNode.Key, _validNeighbour.Key);
            Assert.Throws<InvalidOperationException>(() => _validNode.RemoveNeighbour(_validNeighbour));
        }
    }
}
