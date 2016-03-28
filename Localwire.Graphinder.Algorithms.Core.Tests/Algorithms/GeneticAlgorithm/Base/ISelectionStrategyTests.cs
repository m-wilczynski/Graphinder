namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.SelectionStrategies;
    using Core.Graph;
    using Core.Problems;
    using Exceptions;
    using Providers;
    using Providers.SubstituteData;
    using Providers.TestData;
    using Xunit;

    public abstract class ISelectionStrategyTests
    {
        protected ISelectionStrategy Strategy;
        protected readonly ITestDataProvider<ICollection<Individual>> IndividualProvider = new IndividualsProvider();
        protected readonly ITestDataProvider<Graph> GraphDataProvider = new GraphProvider();
        protected readonly ISubstituteProvider<IProblem> ProblemProvider = new ProblemSubstituteProvider(); 

        protected ISelectionStrategyTests()
        {
        }

        [Fact]
        public void ISelectionStrategy_Set_ThrowsOnNullPopulation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Strategy.Set(null);
            });

            Strategy.Set(IndividualProvider.ProvideValid());
        }

        [Fact]
        public void ISelectionStrategy_Set_ThrowsOnProblemMismatch()
        {
            Assert.Throws<AlgorithmException>(() =>
            {
                var graph = GraphDataProvider.ProvideValid();
                var problem = ProblemProvider.ProvideSubstitute();
                var individuals = new List<Individual>
                {
                    new Individual(graph, problem),
                    new Individual(graph, ProblemProvider.ProvideSubstitute())
                };
                Strategy.Set(individuals);
            });
        }

        [Fact]
        public void ISelectionStrategy_Set_ThrowsOnGraphMismatch()
        {
            Assert.Throws<AlgorithmException>(() =>
            {
                var graph = GraphDataProvider.ProvideValid();
                var problem = ProblemProvider.ProvideSubstitute();
                var individuals = new List<Individual>
                {
                    new Individual(graph, problem),
                    new Individual(GraphDataProvider.ProvideValid(), problem)
                };
                Strategy.Set(individuals);
            });
        }

        [Fact]
        public void ISelectionStrategy_Next_ReturnsValid()
        {
            var individuals = IndividualProvider.ProvideValid();
            Strategy.Set(individuals);
            var next = Strategy.Next();
            Assert.True(individuals.Any(i => i.Equals(next)));
        }

        [Fact]
        public void ISelectionStrategy_Next_ReturnsProperValueIfOneIndividualPopulation()
        {
            var individuals = IndividualProvider.ProvideValid().Take(1).ToList();
            Strategy.Set(individuals);
            var next = Strategy.Next();
            Assert.True(individuals.Any(i => i.Equals(next)));
        }

        [Fact]
        public void ISelectionStrategy_NextCouple_ReturnsValid()
        {
            var individuals = IndividualProvider.ProvideValid();
            Strategy.Set(individuals);
            var couple = Strategy.NextCouple();
            Assert.Contains(individuals, i => i.Equals(couple.Item1));
            Assert.Contains(individuals, i => i.Equals(couple.Item2));
            Assert.False(couple.Item1.Equals(couple.Item2));
        }

        [Fact]
        public void ISelectionStrategy_NextCouple_ThrowOnPopulationLessThanTwo()
        {
            var individuals = IndividualProvider.ProvideValid().Take(1).ToList();
            Strategy.Set(individuals);
            Assert.Throws<InvalidOperationException>(() => Strategy.NextCouple());
        }

    }
}
