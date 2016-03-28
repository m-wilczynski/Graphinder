namespace Localwire.Graphinder.Core.Tests.Providers.SubstituteData
{
    using System;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Algorithms.GeneticAlgorithm.MutationStrategies;
    using NSubstitute;

    public class MutationStrategyProvider : ISubstituteProvider<IMutationStrategy>
    {
        /// <summary>
        /// Provides wired mocked instance of declared type.
        /// </summary>
        /// <returns></returns>
        public IMutationStrategy ProvideSubstitute()
        {
            var substitute = Substitute.For<IMutationStrategy>();
            MutateSetup(substitute);
            return substitute;
        }

        private void MutateSetup(IMutationStrategy strategy)
        {
            strategy.When(s => s.Mutate(null)).Throw<ArgumentNullException>();
            //Do nothing so far
            strategy.When(s => s.Mutate(Arg.Any<Individual>())).Do(s => s.Arg<Individual>());
        }
    }
}
