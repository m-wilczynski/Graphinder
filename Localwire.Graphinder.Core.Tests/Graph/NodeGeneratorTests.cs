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

        //TODO: Test actual results of generator
        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ReturnsValidAmountOfNodes()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void NodeGenerator_ProvideNodeCollection_ReturnsValidRangeOfNeighours()
        {
            throw new NotImplementedException();
        }
    }
}
