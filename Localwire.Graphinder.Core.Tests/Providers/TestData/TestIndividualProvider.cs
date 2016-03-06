namespace Localwire.Graphinder.Core.Tests.Providers.TestData
{
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Graph;
    using Core.Problems;
    using SubstituteData;

    public class TestIndividualProvider : ITestDataProvider<Individual>
    {
        private readonly ITestDataProvider<Graph> _graphProvider = new TestGraphProvider();
        private readonly ISubstituteProvider<IProblem> _problemProvider = new ProblemSubstituteProvider();

        /// <summary>
        /// Provides valid instance of declared type.
        /// </summary>
        /// <returns></returns>
        public Individual ProvideValid()
        {
            return new Individual(_graphProvider.ProvideValid(), _problemProvider.ProvideSubstitute());
        }
    }
}
