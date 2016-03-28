namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using Core.Graph;
    using NSubstitute;
    using Providers;
    using Providers.SubstituteData;
    using Providers.TestData;
    using Xunit;

    public class GeneticAlgorithmTests : AlgorithmTests
    {
        private readonly ISubstituteProvider<GeneticOperators> _operatorsProvider = new GeneticOperatorsProvider(); 
        private readonly ITestDataProvider<GeneticAlgorithmSettings> _settingsProvider = new GeneticAlgorithmSettingsProvider();
        private GeneticAlgorithm _geneticAlgorithmThatAlwaysCrossoversAndMutates;
        private GeneticAlgorithm _geneticAlgorithmThatHasLotsOfGenerations;
        private GeneticAlgorithm _geneticAlgorithmThatAlwaysCrossoversAndMutatesAndPerformsElitism;

        public GeneticAlgorithmTests()
        {
            Algorithm = new GeneticAlgorithm(_graphFactory.ProvideValid(), 
                _problemProvider.ProvideSubstitute(), 
                _operatorsProvider.ProvideSubstitute(), 
                _settingsProvider.ProvideValid());
            _geneticAlgorithmThatAlwaysCrossoversAndMutates = new GeneticAlgorithm(_graphFactory.ProvideValid(),
                _problemProvider.ProvideSubstitute(),
                _operatorsProvider.ProvideSubstitute(),
                new GeneticAlgorithmSettings(generationsToCome: 1, crossoverProbability: 1d, mutationProbability: 1d));
            _geneticAlgorithmThatHasLotsOfGenerations = new GeneticAlgorithm(_graphFactory.ProvideValid(),
                _problemProvider.ProvideSubstitute(),
                _operatorsProvider.ProvideSubstitute(),
                new GeneticAlgorithmSettings(generationsToCome: 20, initialPopulationSize: 4));
            _geneticAlgorithmThatAlwaysCrossoversAndMutatesAndPerformsElitism = new GeneticAlgorithm(_graphFactory.ProvideValid(),
                _problemProvider.ProvideSubstitute(),
                _operatorsProvider.ProvideSubstitute(),
                new GeneticAlgorithmSettings(generationsToCome: 1, crossoverProbability: 1d, mutationProbability: 1d, withElitistSelection: true));
        }

        [Fact]
        public void GeneticAlgorithm_ctor_ThrowsOnNullGraph()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GeneticAlgorithm(null, _problemProvider.ProvideSubstitute(), 
                    _operatorsProvider.ProvideSubstitute(), _settingsProvider.ProvideValid());
            });
        }

        [Fact]
        public void GeneticAlgorithm_ctor_ThrowsOnInvalidGraph()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new GeneticAlgorithm(new Graph(), _problemProvider.ProvideSubstitute(),
                    _operatorsProvider.ProvideSubstitute(), _settingsProvider.ProvideValid());
            });
        }

        [Fact]
        public void GeneticAlgorithm_ctor_ThrowsOnNullProblem()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GeneticAlgorithm(_graphFactory.ProvideValid(), null,
                    _operatorsProvider.ProvideSubstitute(), _settingsProvider.ProvideValid());
            });
        }

        [Fact]
        public void GeneticAlgorithm_ctor_ThrowsOnNullGeneticOperators()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GeneticAlgorithm(_graphFactory.ProvideValid(), _problemProvider.ProvideSubstitute(),
                    null, _settingsProvider.ProvideValid());
            });
        }

        [Fact]
        public void GeneticAlgorithm_ctor_ThrowsOnInvalidGeneticOperators()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GeneticAlgorithm(_graphFactory.ProvideValid(), _problemProvider.ProvideSubstitute(),
                    new GeneticOperators(null, null, null), _settingsProvider.ProvideValid());
            });
        }

        [Fact]
        public void GeneticAlgorithm_ctor_ThrowsOnNullAlgorithmSettings()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GeneticAlgorithm(_graphFactory.ProvideValid(), _problemProvider.ProvideSubstitute(),
                    _operatorsProvider.ProvideSubstitute(), null);
            });
        }

        [Fact]
        public void GeneticAlgorithm_LaunchAlgorithm_ResetsSelectionStrategyPopulation()
        {
            var algorithm = Algorithm as GeneticAlgorithm;
            if (algorithm == null)
                throw new InvalidCastException("GeneticAlgorithm");
            algorithm.LaunchAlgorithm();
            BlockTestExecutionUntilLaunchAlgorithmFinishes(algorithm);
            algorithm.GeneticOperators.SelectionStrategy.Received().Set(Arg.Any<ICollection<Individual>>());        
        }

        [Fact]
        public void GeneticAlgorithm_LaunchAlgorithm_UsesSelectionStrategyForChoosing()
        {
            var algorithm = Algorithm as GeneticAlgorithm;
            if (algorithm == null)
                throw new InvalidCastException("GeneticAlgorithm");
            algorithm.LaunchAlgorithm();
            algorithm.GeneticOperators.SelectionStrategy.Received().NextCouple();
        }

        [Fact]
        public void GeneticAlgorithm_LaunchAlgorithm_UsesCrossoverStrategyIfRolled()
        {
            _geneticAlgorithmThatAlwaysCrossoversAndMutates.LaunchAlgorithm();
            _geneticAlgorithmThatAlwaysCrossoversAndMutates.GeneticOperators.CrossoverStrategy.Received()
                .PerformCrossover(Arg.Any<Individual>(), Arg.Any<Individual>());
        }

        [Fact]
        public void GeneticAlgorithm_LaunchAlgorithm_UsesMutationStrategyIfRolled()
        {
            _geneticAlgorithmThatAlwaysCrossoversAndMutates.LaunchAlgorithm();
            BlockTestExecutionUntilLaunchAlgorithmFinishes(_geneticAlgorithmThatAlwaysCrossoversAndMutates);
            _geneticAlgorithmThatAlwaysCrossoversAndMutates.GeneticOperators.MutationStrategy.Received()
                .Mutate(Arg.Any<Individual>());
        }

        [Fact]
        public void GeneticAlgorithm_LaunchAlgorithm_ExecutesUntilCanContinueSearching()
        {
            Assert.Equal(_geneticAlgorithmThatHasLotsOfGenerations.CurrentGeneration, (uint)0);
            _geneticAlgorithmThatHasLotsOfGenerations.LaunchAlgorithm();
            BlockTestExecutionUntilLaunchAlgorithmFinishes(_geneticAlgorithmThatHasLotsOfGenerations);
            Assert.Equal(_geneticAlgorithmThatHasLotsOfGenerations.CurrentGeneration, _geneticAlgorithmThatHasLotsOfGenerations.Settings.GenerationsToCome);
        }

        [Fact]
        public void GeneticAlgorithm_ElitistSelection_PreservesProperNumberOfIndividuals()
        {
            var individuals = _geneticAlgorithmThatAlwaysCrossoversAndMutatesAndPerformsElitism.CurrentPopulation;
            var elite = individuals.LastOrDefault();
            _geneticAlgorithmThatAlwaysCrossoversAndMutatesAndPerformsElitism.LaunchAlgorithm();
            Assert.True(_geneticAlgorithmThatAlwaysCrossoversAndMutatesAndPerformsElitism.CurrentPopulation.Any(i => i.Equals(elite)));
        }
    }
}
