namespace Localwire.Graphinder.Core.Problems.OptimizationProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Graph;
    using Helpers.Extensions;

    /// <summary>
    /// Class representing minimal vertex cover problem and its current solution
    /// </summary>
    public class MinimumVertexCover : IProblem
    {
        private bool _isInitialized;
        private Graph _graph;
        private HashSet<Node> _currentCover;
        private readonly ProblemCriteria _criteria = ProblemCriteria.SmallerIsBetter;

        /// <summary>
        /// Current solution value.
        /// </summary>
        public int CoverSize
        {
            get { return _currentCover.Count; }
        }

        /// <summary>
        /// Problem solution criteria.
        /// </summary>
        public ProblemCriteria Criteria { get { return _criteria; } }

        /// <summary>
        /// Is current, chosen solution correct for the problem?
        /// </summary>
        public bool IsCurrentSolutionCorrect { get { return IsSolutionCorrect(CurrentSolution); } }

        /// <summary>
        /// Is problem already initialized?
        /// </summary>
        public bool IsInitialized { get { return _isInitialized; } }

        /// <summary>
        /// Current solution value.
        /// </summary>
        public int CurrentOutcome { get { return IsCurrentSolutionCorrect ? CoverSize : _graph.TotalNodes; } }

        /// <summary>
        /// Current solution of the problem.
        /// </summary>
        public ICollection<Node> CurrentSolution { get { return new HashSet<Node>(_currentCover); } }

        /// <summary>
        /// Adds new solution of the problem.
        /// </summary>
        /// <param name="nodes">Collection of nodes representing new solution.</param>
        public void AddNewSolution(ICollection<Node> nodes)
        {
            if (nodes == null) throw new ArgumentException(nameof(nodes));
            if (!IsInitialized) return;
            if (nodes.All(n => _graph.Nodes.Any(n1 => n1.Equals(n))))
            {
                _currentCover = new HashSet<Node>(nodes);
            }
        }

        /// <summary>
        /// Initialize the problem with graph data structure.
        /// </summary>
        /// <param name="graph">Graph that represents problem to solve.</param>
        public void Initialize(Graph graph)
        {
            if (graph == null) throw new ArgumentException(nameof(graph));
            if (_isInitialized) return;
            _currentCover = new HashSet<Node>(graph.Nodes);
            _graph = graph;
            _isInitialized = true;
        }

        /// <summary>
        /// Restart problem to initial state.
        /// </summary>
        public void RestartProblemState()
        {
            if (!IsInitialized) return;
            _currentCover = new HashSet<Node>(_graph.Nodes);
        }


        /// <summary>
        /// Checks passed solution for correctness.
        /// </summary>
        /// <param name="nodes">Collection of nodes representing new solution.</param>
        /// <returns>Outcome of correctness check.</returns>
        public bool IsSolutionCorrect(ICollection<Node> nodes)
        {
            if (nodes == null) throw new ArgumentException(nameof(nodes));
            if (!IsInitialized) return false;
            HashSet<Node> alreadyCovered = new HashSet<Node>();
            foreach (var element in nodes)
            {
                alreadyCovered.Add(element);
                alreadyCovered.AddRange(element.Neighbours);
                if (alreadyCovered.Count == _graph.TotalNodes) break;
            }
            return alreadyCovered.Count == _graph.TotalNodes;
        }

        /// <summary>
        /// Checks passed solution encoded binary for correctness.
        /// </summary>
        /// <param name="nodesEncodedBinary">Collection of nodes representing new solution encoded binary.</param>
        /// <returns>Outcome of correctness check.</returns>
        public bool IsSolutionCorrect(bool[] nodesEncodedBinary)
        {
            if (nodesEncodedBinary == null) throw new ArgumentException(nameof(nodesEncodedBinary));
            //TODO: Would be wiser to enumerate over everything only once and break DRY rule up here?
            return IsSolutionCorrect(_graph.BinarySolutionAsNodes(nodesEncodedBinary));
        }

        /// <summary>
        /// Outputs outcome of provided solution.
        /// </summary>
        /// <param name="nodes">Proposed solution.</param>
        /// <returns>Solution outcome if correct. Default solution if incorrect.</returns>
        public int SolutionOutcome(ICollection<Node> nodes)
        {
            if (nodes == null) throw new ArgumentException(nameof(nodes));
            return IsSolutionCorrect(nodes) ? nodes.Count : _graph.TotalNodes;
        }
    }
}
