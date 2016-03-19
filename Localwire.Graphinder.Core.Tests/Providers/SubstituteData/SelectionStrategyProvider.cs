namespace Localwire.Graphinder.Core.Tests.Providers.SubstituteData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using NSubstitute;
    using TestData;

    public class SelectionStrategyProvider : ISubstituteProvider<ISelectionStrategy>
    {
        public readonly ITestDataProvider<ICollection<Individual>> IndividualProvider = new IndividualsProvider(); 

        /// <summary>
        /// Provides wired mocked instance of declared type.
        /// </summary>
        /// <returns></returns>
        public ISelectionStrategy ProvideSubstitute()
        {
            var substitute = Substitute.For<ISelectionStrategy>();
            NextCoupleSetup(substitute);
            return substitute;
        }

        private void NextCoupleSetup(ISelectionStrategy strategy)
        {
            var testIndividuals = IndividualProvider.ProvideValid().ToList();
            if (testIndividuals.Count < 2) throw new InvalidOperationException();
            strategy.NextCouple().Returns(new Tuple<Individual, Individual>(testIndividuals[0], testIndividuals[1]));
        }
    }
}
