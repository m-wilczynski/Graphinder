namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using Core.Algorithms.GeneticAlgorithm;
    using Providers;
    using Providers.SubstituteData;

    public class GeneticAlgorithmTests : AlgorithmTests
    {
        private readonly ISubstituteProvider<GeneticOperators> _operatorsProvider = new GeneticOperatorsProvider(); 

        public GeneticAlgorithmTests()
        {
            _algorithm = new GeneticAlgorithm(_graphFactory.ProvideValid(), _problemProvider.ProvideSubstitute(), _operatorsProvider.ProvideSubstitute());
        }
    }
}
