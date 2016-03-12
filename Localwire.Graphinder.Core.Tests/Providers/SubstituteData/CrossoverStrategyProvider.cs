namespace Localwire.Graphinder.Core.Tests.Providers.SubstituteData
{
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using NSubstitute;

    public class CrossoverStrategyProvider : ISubstituteProvider<ICrossoverStrategy>
    {
        /// <summary>
        /// Provides wired mocked instance of declared type.
        /// </summary>
        /// <returns></returns>
        public ICrossoverStrategy ProvideSubstitute()
        {
            return Substitute.For<ICrossoverStrategy>();
        }
    }
}
