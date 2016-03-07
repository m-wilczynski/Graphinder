namespace Localwire.Graphinder.Core.Tests.Graph
{
    using System;
    using Core.Graph;
    using Exceptions;
    using Xunit;

    public class GraphTests
    {
        private Graph _validGraph;

        public GraphTests()
        {
            _validGraph = new Graph();
        }

        [Fact]
        public void Graph_ctor_ThrowOnNullCollection()
        {
            Assert.Throws<ArgumentNullException>(() => new Graph(null));
        }

        [Fact]
        public void Graph_FillGraphRandomly_GeneratesCorrectNumberOfNodes()
        {
            _validGraph.FillGraphRandomly(3, 2);
            Assert.Equal(_validGraph.TotalNodes, 3);
        }

        [Fact]
        public void Graph_FillGraphRandomly_LocksGraph()
        {
            _validGraph.FillGraphRandomly(3, 2);
            Assert.Equal(false, _validGraph.CanAdd());
        }

        [Fact]
        public void Graph_FillGraphRandomly_ThrowsIfGraphLocked()
        {
            _validGraph.LockGraph();
            Assert.Throws<DataStructureLockedException>(() => _validGraph.FillGraphRandomly(10, 2));
        }

        [Fact]
        public void Graph_AddNode_ValidNodeAdded()
        {
            _validGraph.AddNode("1");
            Assert.Equal(1, _validGraph.TotalNodes);
        }

        [Fact]
        public void Graph_AddNode_ThrowIfGraphLocked()
        {
            _validGraph.LockGraph();
            Assert.Throws<DataStructureLockedException>(() => _validGraph.AddNode("1"));
        }

        [Fact]
        public void Graph_AddNode_ThrowIfDuplicateNodeAttempt()
        {
            _validGraph.AddNode("1");
            Assert.Throws<InvalidOperationException>(() => _validGraph.AddNode("1"));
        }

        [Fact]
        public void Graph_RemoveNode_ValidNodeRemoved()
        {
            var node = _validGraph.AddNode("1");
            _validGraph.AddNode("2");
            _validGraph.AddEdge("1", "2");
            //Assert proper setup
            Assert.Equal(2, _validGraph.TotalNodes);
            Assert.Equal(1, _validGraph.TotalEdges);

            _validGraph.RemoveNode(node.Key);
            //Assert proper removal
            Assert.Equal(1, _validGraph.TotalNodes);
            Assert.Equal(0, _validGraph.TotalEdges);
        }

        [Fact]
        public void Graph_RemoveNode_ThrowIfGraphLocked()
        {
            var node = _validGraph.AddNode("1");
            _validGraph.LockGraph();
            Assert.Throws<DataStructureLockedException>(() => _validGraph.RemoveNode(node.Key));
        }

        [Fact]
        public void Graph_RemoveNode_ThrowIfNodeNotFound()
        {
            _validGraph.AddNode("1");
            Assert.Throws<InvalidOperationException>(() => _validGraph.RemoveNode("2"));
        }


    }
}
