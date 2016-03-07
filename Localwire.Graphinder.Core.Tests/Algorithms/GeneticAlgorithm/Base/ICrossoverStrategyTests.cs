namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm.Base
{
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Graph;
    using Core.Problems;
    using Providers;
    using Providers.SubstituteData;
    using Providers.TestData;

    public abstract class ICrossoverStrategyTests
    {
        protected ICrossoverStrategy _strategy;
        private readonly ITestDataProvider<Graph> _graphProvider = new TestGraphProvider();
        private readonly ISubstituteProvider<IProblem> _problemProvider = new ProblemSubstituteProvider();

        protected ICrossoverStrategyTests()
        {
        }  
    }
}
