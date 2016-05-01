namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.Setup
{
    using System;
    using CrossoverStrategies;
    using Helpers;
    using MutationStrategies;
    using SelectionStrategies;

    /// <summary>
    /// Represents every genetic operator that will be used on new generation breeding.
    /// </summary>
    public class GeneticOperators : ISelfValidable
    {
        /// <summary>
        /// Strategy for selecting individuals for crossover.
        /// </summary>
        public readonly ISelectionStrategy SelectionStrategy;
        
        /// <summary>
        /// Strategy for crossing individuals to breed new one.
        /// </summary>
        public readonly ICrossoverStrategy CrossoverStrategy;
        
        /// <summary>
        /// Strategy for mutating newly bred individual.
        /// </summary>
        public readonly IMutationStrategy MutationStrategy;

        /// <summary>
        /// Creates setup of genetic operators for <see cref="T:Localwire.Graphinder.Algorithms.Core.Algorithms.GeneticAlgorithm.GenetichAlgorithm"/>
        /// </summary>
        /// <param name="selectionStrategy">Selection strategy</param>
        /// <param name="crossoverStrategy">Crossover strategy</param>
        /// <param name="mutationStrategy">Mutation strategy</param>
        public GeneticOperators(ISelectionStrategy selectionStrategy,
            ICrossoverStrategy crossoverStrategy, IMutationStrategy mutationStrategy)
        {
            if (selectionStrategy == null)
                throw new ArgumentNullException(nameof(selectionStrategy));
            if (crossoverStrategy == null)
                throw new ArgumentNullException(nameof(crossoverStrategy));
            if (mutationStrategy == null)
                throw new ArgumentNullException(nameof(mutationStrategy));
            SelectionStrategy = selectionStrategy;
            MutationStrategy = mutationStrategy;
            CrossoverStrategy = crossoverStrategy;
        }

        /// <summary>
        /// Decides if state of object is valid.
        /// </summary>
        public bool IsValid()
        {
            return SelectionStrategy != null && CrossoverStrategy != null && MutationStrategy != null;
        }
    }
}
