namespace Localwire.Graphinder.Core.Tests.Providers.TestData
{
    using System;
    using System.Collections.Generic;
    using Core.Graph;

    public class TestGraphProvider : ITestDataProvider<Graph>
    {
        /// <summary>
        /// Provides valid instance of declared type.
        /// </summary>
        /// <returns></returns>
        public Graph ProvideValid()
        {
            return new Graph(new List<string>
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            });
        }
    }
}
