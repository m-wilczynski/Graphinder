namespace Localwire.Graphinder.Core.Tests.Providers.SubstituteData
{
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using NSubstitute;

    public class MutationStrategyProvider : ISubstituteProvider<IMutationStrategy>
    {
        /// <summary>
        /// Provides wired mocked instance of declared type.
        /// </summary>
        /// <returns></returns>
        public IMutationStrategy ProvideSubstitute()
        {
            return Substitute.For<IMutationStrategy>();
        }
    }
}
