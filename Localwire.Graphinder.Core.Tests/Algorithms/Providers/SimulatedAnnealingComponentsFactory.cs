namespace Localwire.Graphinder.Core.Tests.Algorithms.Providers
{
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using NSubstitute;

    public class SimulatedAnnealingComponentsFactory
    {
        public CoolingSetup ProvideValidCoolingSetup()
        {
            return new CoolingSetup(100, 0.1, Substitute.For<ICoolingStrategy>());
        }
    }
}
