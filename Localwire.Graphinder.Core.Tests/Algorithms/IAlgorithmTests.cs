namespace Localwire.Graphinder.Core.Tests.Algorithms
{
    using System;
    using Core.Algorithms;
    using Xunit;

    public abstract class IAlgorithmTests
    {
        protected IAlgorithm _algorithm;

        protected IAlgorithmTests()
        { }

        [Fact]
        public void IAlgorithm_CanAcceptAnswer_ThrowsOnNullAnswer()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _algorithm.CanAcceptAnswer(null);
            });
        }
    }
}
