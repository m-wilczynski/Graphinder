namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.Setup
{
    using System;
    using CrossoverStrategies;
    using MutationStrategies;
    using SelectionStrategies;

    public class GeneticOperators
    {
        public class GeneticAlgorithmSetup
        {
            public ISelectionStrategy SelectionStrategy { get; set; }
            public ICrossoverStrategy CrossoverStrategy { get; set; }
            public IMutationStrategy MutationStrategy { get; set; }

            public GeneticAlgorithmSetup(ISelectionStrategy selectionStrategy,
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
        }
    }
}
