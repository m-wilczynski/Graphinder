namespace Localwire.Graphinder.Core.Tests.Providers.TestData
{
    using System.Collections.Generic;
    using Core.Graph;

    public class TestGraphProvider : ITestDataProvider<Graph>
    {
        public Graph ProvideValid()
        {
            return new Graph(new List<string> { "1", "2", "3"});
        }
    }
}
