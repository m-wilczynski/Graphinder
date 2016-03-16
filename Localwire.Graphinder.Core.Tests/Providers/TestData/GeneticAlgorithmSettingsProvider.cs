namespace Localwire.Graphinder.Core.Tests.Providers.TestData
{
    using Core.Algorithms.GeneticAlgorithm.Setup;
    public class GeneticAlgorithmSettingsProvider : ITestDataProvider<GeneticAlgorithmSettings>
    {
        /// <summary>
        /// Provides valid instance of declared type.
        /// </summary>
        /// <returns></returns>
        public GeneticAlgorithmSettings ProvideValid()
        {
            return new GeneticAlgorithmSettings();
        }
    }
}
