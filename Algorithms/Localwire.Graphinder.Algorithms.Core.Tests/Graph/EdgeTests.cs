namespace Localwire.Graphinder.Core.Tests.Graph
{
    using System;
    using Core.Graph;
    using Providers;
    using Providers.TestData;
    using Xunit;

    public class EdgeTests
    {
        private readonly ITestDataProvider<Graph> _graphProvider = new GraphProvider();
        private readonly Node _validNode1, _validNode2, _validNode3;
        private readonly Node _otherGraphNode;
        private readonly Node _notAddedNode;
        private readonly Graph _graph;

        public EdgeTests()
        {
            _graph = _graphProvider.ProvideValid();
            _validNode1 = _graph.AddNode("1");
            _validNode2 = _graph.AddNode("2");
            _validNode3 = _graph.AddNode("3");
            _otherGraphNode = _graphProvider.ProvideValid().AddNode("1");
            _notAddedNode = new Node("5", _graph);
        }

        [Fact]
        public void Edge_ctor_ThrowsOnNullFromOrTo()
        {
            //Null To node
            Assert.Throws<ArgumentNullException>(() => new Edge(null, _validNode1));
            //Null From node
            Assert.Throws<ArgumentNullException>(() => new Edge(_validNode1, null));
            //Valid one
            var valid = new Edge(_validNode1, _validNode2);
        }

        [Fact]
        public void Edge_ctor_ThrowsOnGraphMismatch()
        {
            Assert.Throws<ArgumentException>(() => new Edge(_validNode1, _otherGraphNode));
        }

        [Fact]
        public void Edge_ctor_ThrowsOnKeyNotFound()
        {
            Assert.Throws<ArgumentException>(() => new Edge(_validNode1, _notAddedNode));
        }

        [Fact]
        public void Edge_Equals_AcceptsValid()
        {
            Assert.Equal(new Edge(_validNode1, _validNode2), new Edge(_validNode1, _validNode2));
        }
        
        [Fact]
        public void Edge_Equals_AcceptsInterchangeability()
        {
            //Interchangeable nodes
            Assert.Equal(new Edge(_validNode1, _validNode2), new Edge(_validNode2, _validNode1));
            //Different nodes
            Assert.NotEqual(new Edge(_validNode1, _validNode2), new Edge(_validNode1, _validNode3));
        }
    }
}
