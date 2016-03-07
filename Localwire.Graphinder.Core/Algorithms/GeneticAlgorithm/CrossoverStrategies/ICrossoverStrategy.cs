namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm.CrossoverStrategies
{
    using Problems;

    /// <summary>
    /// Defines crossover strategy of genetic algorithm.
    /// </summary>
    public interface ICrossoverStrategy
    {
        /// <summary>
        /// Point of crossing over individual's genotype.
        /// </summary>
        int CrossoverPointIndex { get; }

        /// <summary>
        /// Perform cross over two individuals' genotypes.
        /// </summary>
        /// <param name="leftParent">Left parent for new genotype.</param>
        /// <param name="rightParent">Right parent for new genotype.</param>
        /// <returns>Result of crossing over - new offspring.</returns>
        Individual PerformCrossover(Individual leftParent, Individual rightParent);
    }
}
