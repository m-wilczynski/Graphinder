namespace Localwire.Graphinder.Core.Tests.Providers.SubstituteData
{
    using System;
    using System.Linq;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.CrossoverStrategies;
    using NSubstitute;

    public class CrossoverStrategyProvider : ISubstituteProvider<ICrossoverStrategy>
    {
        /// <summary>
        /// Provides wired mocked instance of declared type.
        /// </summary>
        /// <returns></returns>
        public ICrossoverStrategy ProvideSubstitute()
        {
            var substitute = Substitute.For<ICrossoverStrategy>();
            PerformCrossoverSetup(substitute);
            return substitute;
        }

        private void PerformCrossoverSetup(ICrossoverStrategy strategy)
        {
            //strategy.When(s => s.PerformCrossover(null, Arg.Any<Individual>()))
            //    .Throw<ArgumentNullException>();
            //strategy.When(s => s.PerformCrossover(Arg.Any<Individual>(), null))
            //    .Throw<ArgumentNullException>();
            strategy.PerformCrossover(Arg.Any<Individual>(), Arg.Any<Individual>())
                .Returns(s =>
                {
                    var firstParent = s.Args().OfType<Individual>().FirstOrDefault();
                    if (firstParent == null)
                        throw new ArgumentNullException();
                    return new Individual(firstParent.Graph, firstParent.Problem, firstParent.CurrentSolution);
                });
        }
    }
}
