namespace Localwire.Graphinder.Core.Tests.Algorithms.Providers
{
    using System.Collections.Generic;
    using Graph;

    public class TestGraphProvider : ITestDataProvider<Graph>
    {
        public Graph ProvideValid()
        {
            return new Graph(new List<string> { "1", "2", "3"});
        }
    }
}
