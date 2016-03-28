namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using System;
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using Providers;
    using Providers.SubstituteData;
    using Xunit;

    public class GeneticOperatorsTests
    {
        private readonly ISubstituteProvider<ICrossoverStrategy> _crossoverProvider = new CrossoverStrategyProvider();
        private readonly ISubstituteProvider<IMutationStrategy> _mutationProvider = new MutationStrategyProvider();
        private readonly ISubstituteProvider<ISelectionStrategy> _selectionProvider = new SelectionStrategyProvider();

        [Fact]
        public void GeneticOperators_ctor_ThrowsOnNullCrossoverStrategy()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GeneticOperators(_selectionProvider.ProvideSubstitute(),
                    null,
                    _mutationProvider.ProvideSubstitute());
            });
        }

        [Fact]
        public void GeneticOperators_ctor_ThrowsOnNullMutationStrategy()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GeneticOperators(_selectionProvider.ProvideSubstitute(),
                    _crossoverProvider.ProvideSubstitute(),
                    null);
            });
        }

        [Fact]
        public void GeneticOperators_ctor_ThrowsOnNullSelectionStrategy()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GeneticOperators(null,
                    _crossoverProvider.ProvideSubstitute(),
                    _mutationProvider.ProvideSubstitute());
            });
        }
    }
}
