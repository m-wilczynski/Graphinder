namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Algorithms.GeneticAlgorithm
{
    using System.Collections.Generic;
    using Mappers.EnumMappings.StrategyTypes;

    internal class GeneticAlgorithmEntity : AlgorithmEntity
    {
        public SelectionStrategyType SelectionStrategy { get; set; }
        public CrossoverStrategyType CrossoverStrategy { get; set; }
        public MutationStrategyType MutationStrategy { get; set; }
        public uint InitialPopulationSize { get; set; }
        public uint GenerationsToCome { get; set; }
        public double CrossoverProbability { get; set; }
        public double WithElitistSelection { get; set; }
        public uint EliteSurvivors { get; set; }
        public uint CurrentGeneration { get; set; }
        public ICollection<IndividualEntity> CurrentPopulation { get; set; }
    }
}
