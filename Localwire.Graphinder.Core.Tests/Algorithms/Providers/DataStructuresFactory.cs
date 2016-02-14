namespace Localwire.Graphinder.Core.Tests.Algorithms.Providers
{
    using System.Collections.Generic;
    using Graph;

    public class DataStructuresFactory
    {
        public Graph ProvideValidGraph()
        {
            return new Graph(new List<string> { "1", "2", "3"});
        }
    }
}
