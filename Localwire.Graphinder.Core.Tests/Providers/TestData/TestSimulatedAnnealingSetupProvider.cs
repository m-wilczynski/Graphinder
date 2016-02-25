namespace Localwire.Graphinder.Core.Tests.Providers.TestData
{
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Core.Problems;
    using Graph;
    using NSubstitute;

    public class TestSimulatedAnnealingSetupProvider : ITestDataProvider<SimulatedAnnealingSetup>
    {
        private readonly ITestDataProvider<Graph> _graphFactory = new TestGraphProvider();
        private readonly ITestDataProvider<CoolingSetup> _coolingSetupFactory = new TestCoolingSetupProvider();
             
        public SimulatedAnnealingSetup ProvideValid()
        {
            return new SimulatedAnnealingSetup(_graphFactory.ProvideValid(),
                Substitute.For<IProblem>(), _coolingSetupFactory.ProvideValid());
        }
    }
}
