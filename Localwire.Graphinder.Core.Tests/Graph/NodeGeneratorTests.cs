namespace Localwire.Graphinder.Core.Tests.Graph
{
    using System;
    using Core.Graph.Helpers;
    using Xunit;

    public class NodeGeneratorTests
    {
        private NodeGenerator _generator;

        public NodeGeneratorTests()
        {
            _generator = new NodeGenerator();
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ThrowsMaxValueNodeCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _generator.ProvideNodeCollection(UInt32.MaxValue);
            });

            _generator.ProvideNodeCollection(3);
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ThrowsMaxValueMaxNeighbours()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _generator.ProvideNodeCollection(2, UInt32.MaxValue);
            });

            _generator.ProvideNodeCollection(4, 2);
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ThrowsOnEqualOrLessNodesThanNeighbours()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _generator.ProvideNodeCollection(2, 2);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _generator.ProvideNodeCollection(3, 4);
            });

            _generator.ProvideNodeCollection(4, 3);
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ReturnsValidAmountOfNodes()
        {
            var generated = _generator.ProvideNodeCollection(10);
            Assert.Equal(generated.Count, 10);
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ReturnsValidRangeOfNeighours()
        {
            const uint nodesCount = 2000;
            const uint nghMax = 10;
            var generated = _generator.ProvideNodeCollection(nodesCount, nghMax);
            foreach (var element in generated)
            {
                var count = element.Neighbours.Count;
                Assert.True(element.Neighbours.Count <= nghMax && element.Neighbours.Count > 0);
            }

        }
    }
}
