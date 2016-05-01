namespace Localwire.Graphinder.Core.Tests.Providers.SubstituteData
{
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Core.Algorithms.GeneticAlgorithm.Setup;

    public class GeneticOperatorsProvider : ISubstituteProvider<GeneticOperators>
    {
        private readonly ISubstituteProvider<ICrossoverStrategy> _crossoverProvider = new CrossoverStrategyProvider();
        private readonly ISubstituteProvider<IMutationStrategy> _mutationProvider = new MutationStrategyProvider();
        private readonly ISubstituteProvider<ISelectionStrategy> _selectionProvider = new SelectionStrategyProvider();

        /// <summary>
        /// Provides wired mocked instance of declared type.
        /// </summary>
        /// <returns></returns>
        public GeneticOperators ProvideSubstitute()
        {
            return new GeneticOperators(_selectionProvider.ProvideSubstitute(), 
                _crossoverProvider.ProvideSubstitute(),
                _mutationProvider.ProvideSubstitute());
        }
    }
}
