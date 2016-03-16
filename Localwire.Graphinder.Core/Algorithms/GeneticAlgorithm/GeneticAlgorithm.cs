namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm
{
    using System.Collections.Generic;
    using Graph;
    using Problems;
    using Setup;

    /// <summary>
    /// Represents genetic algorithm that bases on graph data structure.
    /// </summary>
    public class GeneticAlgorithm : Algorithm
    {
        /// <summary>
        /// Creates instance of genetic algorithm
        /// </summary>
        /// <param name="graph">Graph on which algorithm will operate</param>
        /// <param name="problem">Problem for which algorithm will attempt to find solution</param>
        /// <param name="geneticOperators">Genetic operators used for breeding new generations</param>
        /// <param name="settings">General settings for solution finding process</param>
        public GeneticAlgorithm(Graph graph, IProblem problem, 
            GeneticOperators geneticOperators, GeneticAlgorithmSettings settings) : base(graph, problem)
        {
            throw new System.NotImplementedException();
        }

        public override long ProcessorTimeCost { get; }
        public override int CurrentSolution { get; }
        public uint PopulationSize { get; set; }
        public uint GenerationsToCome { get; }
        public uint CurrentGeneration { get; private set; }

        public override bool CanAcceptAnswer(ICollection<Node> proposedSolution)
        {
            throw new System.NotImplementedException();
        }

        public override bool CanContinueSearching()
        {
            throw new System.NotImplementedException();
        }

        protected override void SearchForSolution()
        {
            throw new System.NotImplementedException();
        }
    }
}
