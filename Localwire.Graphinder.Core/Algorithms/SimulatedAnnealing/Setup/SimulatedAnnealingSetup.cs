namespace Localwire.Graphinder.Core.Algorithms.SimulatedAnnealing.Setup
{
    using System;
    using Graph;
    using Problems;

    /// <summary>
    /// Class representing problem and data structure setup for simulated annealing algorithm
    /// </summary>
    public class SimulatedAnnealingSetup : IAlgorithmSetup
    {
        /// <summary>
        /// Creates setup for simulated annealing algorithm
        /// </summary>
        /// <param name="graph">Graph on which algorithm will operate.</param>
        /// <param name="problem">Problem for which solution will be searched.</param>
        /// <param name="coolSetup">Setup for cooling the system.</param>
        public SimulatedAnnealingSetup(Graph graph, IProblem problem, CoolingSetup coolSetup)
        {
            if (graph == null || !graph.IsValid)
                throw new ArgumentException(nameof(graph));
            if (problem == null)
                throw new ArgumentException(nameof(problem));
            if (coolSetup == null || !coolSetup.IsValid)
                throw new ArgumentException(nameof(coolSetup));
            Graph = graph;
            Problem = problem;
            CoolingSetup = coolSetup;
        }

        /// <summary>
        /// Graph on which algorithm operate.
        /// </summary>
        public Graph Graph { get; private set; }

        /// <summary>
        /// Problem for which algorithm will search for solution.
        /// </summary>
        public IProblem Problem { get; private set; }

        /// <summary>
        /// Setup for system cooling
        /// </summary>
        public CoolingSetup CoolingSetup { get; private set; }

        /// <summary>
        /// Decides if state of object valid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return Graph != null && Graph.IsValid && Problem != null && CoolingSetup != null && CoolingSetup.IsValid;
            }
        }
    }
}
