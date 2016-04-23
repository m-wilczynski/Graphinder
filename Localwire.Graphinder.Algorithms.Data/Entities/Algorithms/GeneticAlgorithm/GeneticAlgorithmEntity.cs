namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Algorithms.GeneticAlgorithm
{
    using System.Collections.Generic;
    using Mappers.EnumMappings.StrategyTypes;

    internal class GeneticAlgorithmEntity : AlgorithmEntity
    {
        public SelectionStrategyType SelectionStrategy { get; set; }
        public CrossoverStrategyType CrossoverStrategy { get; set; }
        public MutationStrategyType MutationStrategy { get; set; }
        public int InitialPopulationSize { get; set; }
        public int GenerationsToCome { get; set; }
        public double CrossoverProbability { get; set; }
        public double MutationProbability { get; set; }
        public bool WithElitistSelection { get; set; }
        public int EliteSurvivors { get; set; }
        public int CurrentGeneration { get; set; }
        public ICollection<IndividualEntity> CurrentPopulation { get; set; }
    }
}
