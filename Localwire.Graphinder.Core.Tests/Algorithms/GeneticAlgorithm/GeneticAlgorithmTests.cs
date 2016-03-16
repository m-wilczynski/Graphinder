namespace Localwire.Graphinder.Core.Tests.Algorithms.GeneticAlgorithm
{
    using System;
    using Core.Algorithms.GeneticAlgorithm.Setup;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Graph;
    using Providers;
    using Providers.SubstituteData;
    using Providers.TestData;
    using Xunit;

    public class GeneticAlgorithmTests : AlgorithmTests
    {
        private readonly ISubstituteProvider<GeneticOperators> _operatorsProvider = new GeneticOperatorsProvider(); 
        private readonly ITestDataProvider<GeneticAlgorithmSettings> _settingsProvider = new GeneticAlgorithmSettingsProvider(); 

        public GeneticAlgorithmTests()
        {
            _algorithm = new GeneticAlgorithm(_graphFactory.ProvideValid(), 
                _problemProvider.ProvideSubstitute(), 
                _operatorsProvider.ProvideSubstitute(), 
                _settingsProvider.ProvideValid());
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
            Assert.Throws<ArgumentNullException>(() =>
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
        public void GeneticAlgorithm_ctor_ThrowsOnInvalidAlgorithmSettings()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new GeneticAlgorithm(_graphFactory.ProvideValid(), _problemProvider.ProvideSubstitute(),
                    _operatorsProvider.ProvideSubstitute(), new GeneticAlgorithmSettings(0, 0, 0, 0));
            });
        }
    }
}
