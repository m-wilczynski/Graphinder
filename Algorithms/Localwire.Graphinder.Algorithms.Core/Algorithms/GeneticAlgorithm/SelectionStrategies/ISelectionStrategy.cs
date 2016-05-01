namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.SelectionStrategies
{
    using System;
    using System.Collections.Generic;

    public interface ISelectionStrategy
    {
        /// <summary>
        /// Returns randomly chosen individual.
        /// </summary>
        /// <returns></returns>
        Individual Next();

        /// <summary>
        /// Returns randomly chosen pair of individuals.
        /// </summary>
        /// <returns></returns>
        Tuple<Individual, Individual> NextCouple();

        /// <summary>
        /// Resets strategy with new population of individuals.
        /// </summary>
        /// <param name="newPopulation">New population for strategy.</param>
        void Set(ICollection<Individual> newPopulation);
    }
}
