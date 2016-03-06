namespace Localwire.Graphinder.Core.Tests.Providers.TestData
{
    using Core.Algorithms.SimulatedAnnealing.CoolingStrategies;
    using Core.Algorithms.SimulatedAnnealing.Setup;
    using NSubstitute;

    public class TestCoolingSetupProvider : ITestDataProvider<CoolingSetup>
    {
        /// <summary>
        /// Provides valid instance of declared type.
        /// </summary>
        /// <returns></returns>
        public CoolingSetup ProvideValid()
        {
            return new CoolingSetup(100, 0.1, Substitute.For<ICoolingStrategy>());
        }
    }

}
