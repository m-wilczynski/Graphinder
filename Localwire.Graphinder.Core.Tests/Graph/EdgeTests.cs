namespace Localwire.Graphinder.Core.Tests.Graph
{
    using System;
    using System.Collections.Generic;
    using Core.Graph;
    using Providers;
    using Providers.TestData;
    using Xunit;

    public class EdgeTests
    {
        private readonly ITestDataProvider<Graph> _graphProvider = new TestGraphProvider();
        private readonly Node _validNode1, _validNode2, _validNode3;
        private readonly Graph _graph;

        public EdgeTests()
        {
            _graph = _graphProvider.ProvideValid();
            _validNode1 = new Node("1", _graph);
            _validNode2 = new Node("2", _graph);
            _validNode3 = new Node("3", _graph);
        }

        [Fact]
        public void Edge_ctor_ThrowsOnNullFromOrTo()
        {
            //Null To node
            Assert.Throws<ArgumentNullException>(() => new Edge(null, _validNode1));
            //Null From node
            Assert.Throws<ArgumentNullException>(() => new Edge(_validNode1, null));
            //Valid one
            new Edge(_validNode1, _validNode2);
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
