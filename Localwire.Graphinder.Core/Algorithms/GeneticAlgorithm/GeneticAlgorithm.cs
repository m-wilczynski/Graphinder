namespace Localwire.Graphinder.Core.Algorithms.GeneticAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Graph;
    using Problems;
    using Setup;

    /// <summary>
    /// Represents genetic algorithm that bases on graph data structure.
    /// </summary>
    public class GeneticAlgorithm : Algorithm
    {
        private long _processorTimeCost = long.MaxValue;

        /// <summary>
        /// Operators used for breeding new generation of individuals
        /// </summary>
        public readonly GeneticOperators GeneticOperators;

        /// <summary>
        /// Generael settings for solution finding process
        /// </summary>
        public readonly GeneticAlgorithmSettings Settings;

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
            if (geneticOperators == null)
                throw new ArgumentNullException(nameof(geneticOperators));
            if (!geneticOperators.IsValid())
                throw new ArgumentException("Genetic operators are not valid", nameof(geneticOperators));
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));
            GeneticOperators = geneticOperators;
            Settings = settings;
        }

        /// <summary>
        /// Processor time cost in ticks (1 tick = 100 ns).
        /// </summary>
        public override long ProcessorTimeCost { get { return _processorTimeCost; } }

        /// <summary>
        /// Current generation that algorithm bred.
        /// </summary>
        public uint CurrentGeneration { get; private set; }

        /// <summary>
        /// Decides whether algorithm should accept new solution.
        /// </summary>
        /// <param name="proposedSolution">New solution found by algorithm.</param>
        /// <returns>Decision if algorithm should accept answer.</returns>
        public override bool CanAcceptAnswer(ICollection<Node> proposedSolution)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Decides whether algorithm can proceed with next step of solution searching.
        /// </summary>
        /// <returns>Decision if algorithm can proceed.</returns>
        public override bool CanContinueSearching()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Searches for solution for chosen problem.
        /// </summary>
        protected override void SearchForSolution()
        {
            throw new System.NotImplementedException();
        }
    }
}
