namespace Localwire.Graphinder.Core.Tests.Graph
{
    using System;
    using Core.Graph;
    using Core.Graph.Helpers;
    using Providers;
    using Providers.TestData;
    using Xunit;

    public class NodeGeneratorTests
    {
        private NodeGenerator _generator;
        private readonly ITestDataProvider<Graph> _graphProvider = new GraphProvider();
        private Graph _graph;

        public NodeGeneratorTests()
        {
            _generator = new NodeGenerator();
            _graph = _graphProvider.ProvideValid();
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ThrowsMaxValueNodeCount()
        {
            ResetState();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _generator.ProvideNodeCollection(_graph, UInt32.MaxValue);
            });
            
            _generator.ProvideNodeCollection(_graph, 3);
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ThrowsMaxValueMaxNeighbours()
        {
            ResetState();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _generator.ProvideNodeCollection(_graph, 2, UInt32.MaxValue);
            });

            _generator.ProvideNodeCollection(_graph, 4, 2);
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ThrowsOnEqualOrLessNodesThanNeighbours()
        {
            ResetState();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _generator.ProvideNodeCollection(_graph, 2, 2);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _generator.ProvideNodeCollection(_graph, 3, 4);
            });

            _generator.ProvideNodeCollection(_graph, 4, 3);
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ReturnsValidAmountOfNodes()
        {
            ResetState();
            var generated = _generator.ProvideNodeCollection(_graph, 10);
            Assert.Equal(generated.Count, 10);
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ReturnsValidRangeOfNeighours()
        {
            ResetState();
            const uint nodesCount = 2000;
            const uint nghMax = 10;
            var generated = _generator.ProvideNodeCollection(_graph, nodesCount, nghMax);
            foreach (var element in generated)
            {
                Assert.True(element.Neighbours.Count <= nghMax && element.Neighbours.Count > 0);
            }

        }

        private void ResetState()
        {
            _graph = new Graph();
        }
    }
}
