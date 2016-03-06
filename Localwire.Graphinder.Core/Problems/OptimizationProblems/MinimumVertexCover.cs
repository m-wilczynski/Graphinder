namespace Localwire.Graphinder.Core.Problems.OptimizationProblems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exceptions;
    using Graph;

    /// <summary>
    /// Represents minimal vertex cover problem and its current solution
    /// </summary>
    public class MinimumVertexCover : IProblem
    {
        private bool _isInitialized;
        private Graph _graph;
        private HashSet<Node> _currentCover;
        private readonly ProblemCriteria _criteria = ProblemCriteria.SmallerIsBetter;

        /// <summary>
        /// Instantiates minimum vertex cover problem.
        /// </summary>
        public MinimumVertexCover()
        { }

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
        /// Sets new solution of the problem.
        /// </summary>
        /// <param name="nodes">Collection of nodes representing new solution.</param>
        public void SetNewSolution(ICollection<Node> nodes)
        {
            if (nodes == null) throw new ArgumentException(nameof(nodes));
            if (!IsInitialized) return;
            if (nodes.All(n => _graph.ContainsNode(n.Key) && _graph == n.Parent))
            {
                _currentCover = new HashSet<Node>(nodes);
            }
            else
            {
                throw new ProblemException("Setting new solution", "Graph mismatch or node key not found");
            }
        }

        //TODO: Why on earth not in ctor?
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
            HashSet<Edge> alreadyCovered = new HashSet<Edge>();
            foreach (var element in nodes)
            {
                foreach (var neighbour in element.Neighbours)
                {
                    alreadyCovered.Add(new Edge(element, neighbour));
                }
                if (alreadyCovered.Count == _graph.TotalEdges) break;
            }
            return alreadyCovered.Count == _graph.TotalEdges;
        }

        /// <summary>
        /// Checks passed solution encoded in binary for correctness.
        /// </summary>
        /// <param name="nodesEncodedBinary">Collection of nodes representing new solution encoded in binary.</param>
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
