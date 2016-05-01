namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.MutationStrategies
{
    public interface IMutationStrategy
    {
        /// <summary>
        /// Mutate given encoded individual.
        /// </summary>
        /// <param name="individual">Individual to mutate.</param>
        void Mutate(Individual individual);
    }
}
