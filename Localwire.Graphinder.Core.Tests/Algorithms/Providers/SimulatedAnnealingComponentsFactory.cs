namespace Localwire.Graphinder.Core.Tests.Algorithms.Providers
{
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using Core.Problems;
    using NSubstitute;
    using Problems;

    public class SimulatedAnnealingComponentsFactory
    {
        private readonly DataStructuresFactory _structuresFactory = new DataStructuresFactory();

        public CoolingSetup ProvideValidCoolingSetup()
        {
            return new CoolingSetup(100, 0.1, Substitute.For<ICoolingStrategy>());
        }

        public SimulatedAnnealingSetup ProvideValidSimulatedAnnealingSetup()
        {
            return new SimulatedAnnealingSetup(_structuresFactory.ProvideValidGraph(),
                Substitute.For<IProblem>(), ProvideValidCoolingSetup());
        }
    }

}
