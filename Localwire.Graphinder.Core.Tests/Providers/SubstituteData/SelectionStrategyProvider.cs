namespace Localwire.Graphinder.Core.Tests.Providers.SubstituteData
{
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using NSubstitute;

    public class SelectionStrategyProvider : ISubstituteProvider<ISelectionStrategy>
    {
        /// <summary>
        /// Provides wired mocked instance of declared type.
        /// </summary>
        /// <returns></returns>
        public ISelectionStrategy ProvideSubstitute()
        {
            return Substitute.For<ISelectionStrategy>();
        }
    }
}
