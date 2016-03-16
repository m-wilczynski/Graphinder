namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using System;
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using Xunit;

    public class GeneticAlgorithmSettingsTests
    {
        [Fact]
        public void GeneticAlgorithmSettings_ctor_ThrowsOnInvalidGenerationToCome()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new GeneticAlgorithmSettings(generationsToCome: 0);
            });
        }

        [Fact]
        public void GeneticAlgorithmSettings_ctor_ThrowsOnInvalidPopulationSize()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new GeneticAlgorithmSettings(populationSize: 0);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new GeneticAlgorithmSettings(populationSize: 1);
            });
        }

        [Fact]
        public void GeneticAlgorithmSettings_ctor_ThrowsOnInvalidCrossoverProbability()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new GeneticAlgorithmSettings(crossoverProbability: 0);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new GeneticAlgorithmSettings(crossoverProbability: 1.1);
            });
        }

        [Fact]
        public void GeneticAlgorithmSettings_ctor_ThrowsOnInvalidMutationProbability()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new GeneticAlgorithmSettings(mutationProbability: 0);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new GeneticAlgorithmSettings(mutationProbability: 1.1);
            });
        }


    }
}
