namespace Localwire.Graphinder.Core.Problems.OptimizationProblems
{
    using System.Collections.Generic;
    using System.Linq;
    using Graph;
    using Helpers;

    /// <summary>
    /// Class representing minimal vertex cover problem and its current solution
    /// </summary>
    public class MinimalVertexCover : IProblem
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
        public bool IsCurrentSolutionCorrect { get { return CheckVertexCover(); } }

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
            if (!IsInitialized) return;
            SetNewCover(nodes);
        }

        /// <summary>
        /// Initialize the problem with graph data structure.
        /// </summary>
        /// <param name="graph">Graph that represents problem to solve.</param>
        public void Initialize(Graph graph)
        {
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
            return CheckVertexCover(nodes);
        }

        /// <summary>
        /// Checks passed solution encoded binary for correctness.
        /// </summary>
        /// <param name="nodesEncodedBinary">Collection of nodes representing new solution encoded binary.</param>
        /// <returns>Outcome of correctness check.</returns>
        public bool IsSolutionCorrect(bool[] nodesEncodedBinary)
        {
            //TODO: Would be wiser to enumerate over everything only once and break DRY rule up here?
            return CheckVertexCover(_graph.BinarySolutionAsNodes(nodesEncodedBinary));
        }

        /// <summary>
        /// Sets new solution of a problem, ie. new minimal vertex cover.
        /// Will not add new solution if any of nodes in provided solution does not belong to the graph.
        /// </summary>
        /// <param name="nodes">Collection of nodes representing new solution.</param>
        private void SetNewCover(ICollection<Node> nodes)
        {
            if (!IsInitialized) return;
            if (nodes.All(n => _graph.Nodes.Any(n1 => n1.Equals(n))))
            {
                _currentCover = new HashSet<Node>(nodes);
            }
        }

        /// <summary>
        /// Checks if provided solution (or chosen solution for whole problem) meets Minimal Vertex Cover criteria,
        /// ie. covers all nodes of the graph.
        /// </summary>
        /// <param name="nodes">Collection of nodes representing new solution.</param>
        /// <returns></returns>
        private bool CheckVertexCover(ICollection<Node> nodes = null)
        {
            if (!IsInitialized) return false;
            HashSet<Node> alreadyCovered = new HashSet<Node>();
            foreach (var element in nodes ?? _currentCover)
            {
                alreadyCovered.Add(element);
                alreadyCovered.AddRange(element.Neighbours);
                if (alreadyCovered.Count == _graph.TotalNodes) break;
            }
            return alreadyCovered.Count == _graph.TotalNodes;
        }
    }
}
