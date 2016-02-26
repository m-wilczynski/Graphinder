namespace Localwire.Graphinder.Core.Tests.Providers.TestData
{
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Core.Problems;
    using Core.Graph;
    using SubstituteData;

    public class TestSimulatedAnnealingSetupProvider : ITestDataProvider<SimulatedAnnealingSetup>
    {
        private readonly ITestDataProvider<Graph> _graphFactory = new TestGraphProvider();
        private readonly ITestDataProvider<CoolingSetup> _coolingSetupFactory = new TestCoolingSetupProvider();
        private readonly ISubstituteProvider<IProblem> _problemProvider = new ProblemSubstituteProvider(); 
             
        public SimulatedAnnealingSetup ProvideValid()
        {
            return new SimulatedAnnealingSetup(_graphFactory.ProvideValid(),
                _problemProvider.ProvideSubstitute(), _coolingSetupFactory.ProvideValid());
        }
    }
}
