namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm.Base
{
    using System.Collections.Generic;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using Core.Graph;
    using Core.Problems;
    using Exceptions;
    using Providers;
    using Providers.SubstituteData;
    using Providers.TestData;
    using Xunit;

    public abstract class ICrossoverStrategyTests
    {
        protected ICrossoverStrategy Strategy;
        protected readonly ITestDataProvider<ICollection<Individual>> IndividualProvider = new IndividualsProvider();
        protected readonly ITestDataProvider<Graph> GraphProvider = new GraphProvider();
        protected readonly ISubstituteProvider<IProblem> ProblemProvider = new ProblemSubstituteProvider(); 
        protected Graph ValidGraph;
        protected IProblem ValidProblem;

        protected ICrossoverStrategyTests()
        {
            ValidGraph = GraphProvider.ProvideValid();
            ValidProblem = ProblemProvider.ProvideSubstitute();
        }

        [Fact]
        public void ICrossoverStrategy_PerformCrossover_ValidCrossover()
        {
            var parent1 = new Individual(ValidGraph, ValidProblem);
            var parent2 = new Individual(ValidGraph, ValidProblem);
            var offspring = Strategy.PerformCrossover(parent1, parent2);

            //Only reference check can be performaed here as parents having same genotype
            // will end up having exactly same offspring, thus comparison would eventually fail
            Assert.False(offspring.Equals(parent1));
            Assert.False(offspring.Equals(parent2));
        }

        [Fact]
        public void ICrossoverStrategy_PerformCrossover_ThrowsOnGraphMismatch()
        {
            var parent1 = new Individual(ValidGraph, ValidProblem);
            var parent2 = new Individual(GraphProvider.ProvideValid(), ValidProblem);
            Assert.Throws<AlgorithmException>(() =>
            {
                Strategy.PerformCrossover(parent1, parent2);
            });
        }

        [Fact]
        public void ICrossoverStrategy_PerformCrossover_ThrowsOnProbleMismatch()
        {
            var parent1 = new Individual(ValidGraph, ValidProblem);
            var parent2 = new Individual(ValidGraph, ProblemProvider.ProvideSubstitute());
            Assert.Throws<AlgorithmException>(() =>
            {
                Strategy.PerformCrossover(parent1, parent2);
            });
        }

        [Fact]
        public void ICrossoverStrategy_PerformCrossover_ThrowOnCrossoverBetweenSameIndividual()
        {
            var parent1 = new Individual(ValidGraph, ValidProblem);
            Assert.Throws<AlgorithmException>(() =>
            {
                Strategy.PerformCrossover(parent1, parent1);
            });
        }

        [Fact]
        public void ICrossoverStrategy_PerformCrossover_ThrowOnLengthMismatch()
        {
            var parent1 = new Individual(ValidGraph, ValidProblem);
            ValidGraph.AddNode("Yet another node");
            var parent2 = new Individual(ValidGraph, ValidProblem);
            Assert.Throws<AlgorithmException>(() =>
            {
                Strategy.PerformCrossover(parent1, parent2);
            });
        }

    }
}
