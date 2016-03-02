namespace Localwire.Graphinder.Core.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Helpers;
    using Helpers;

    /// <summary>
    /// Class representing undirected graph data struture.
    /// </summary>
    public class Graph : ISelfValidable
    {
        private bool _isLocked;
        private List<Node> _nodes;
        private readonly Random _random = new Random();
        private Stack<int> _randomNodeIndexes = new Stack<int>();

        public Graph()
        {
            _nodes = new List<Node>();
        }

        public Graph(IEnumerable<string> nodes)
        {
            _nodes = new List<Node>();
            if (nodes != null)
            {
                foreach (var element in nodes.Where(n => n != null && _nodes.All(node => node.Key != n)))
                    AddNode(element);
            }
        }

        /// <summary>
        /// Maximum neighbours per node. Zero if graph wasn't filled with NodeGenerator utility.
        /// </summary>
        public uint MaxNeigbhours { get; private set; }

        /// <summary>
        /// Decides if state of object valid.
        /// </summary>
        public bool IsValid()
        {
            return _nodes != null && _nodes.Count > 0;
        }

        /// <summary>
        /// Return random node from graph
        /// </summary>
        /// <returns></returns>
        public Node GetRandomNode()
        {
            //If sequence of available, preselected, random nodes is empty, refill it
            if (_randomNodeIndexes.Count == 0)
                _randomNodeIndexes = new Stack<int>(Enumerable.Range(0, _nodes.Count).OrderBy(r => _random.Next()));
            return _nodes[_randomNodeIndexes.Pop()];
        }

        /// <summary>
        /// Copy of all graph's elements.
        /// </summary>
        public List<Node> Nodes
        {
            get { return new List<Node>(_nodes); }
        }

        /// <summary>
        /// Total nodes in graph.
        /// </summary>
        public int TotalNodes
        {
            get { return _nodes.Count; }
        }

        /// <summary>
        /// Fills graph with randomly generated data based on seleceted parameters.
        /// </summary>
        /// <param name="nodesCount">Amount of nodes to generate</param>
        /// <param name="maxNeighbours">Maximum number of neighbours per node</param>
        public void FillGraphRandomly(uint nodesCount, uint maxNeighbours)
        {
            if (!CanAdd()) return;
            MaxNeigbhours = maxNeighbours;
            _nodes = new List<Node>(new NodeGenerator().ProvideNodeCollection(nodesCount, maxNeighbours));
            LockGraph();
        }

        /// <summary>
        /// Adds node to the graph.
        /// </summary>
        /// <param name="key">Key representing node to be added</param>
        public void AddNode(string key)
        {
            if (!CanAdd()) return;
            if (_nodes.Any(n => n.Key == key)) return;
            _nodes.Add(new Node(key));
        }

        /// <summary>
        /// Removes node from the graph.
        /// </summary>
        /// <param name="key">Key representing node to be added</param>
        public void RemoveNode(string key)
        {
            if (!CanAdd()) return;
            var match = _nodes.SingleOrDefault(n => n.Key == key);
            if (match == null) return;
            _nodes.Remove(match);
            //Remove relations with other nodes too
            foreach (var ngh in match.Neighbours)
                match.RemoveNeighbour(ngh);
        }

        /// <summary>
        /// Adds edge to the graph.
        /// </summary>
        /// <param name="from">First vertex of an edge.</param>
        /// <param name="to">Second vertex of an edge.</param>
        public void AddEdge(string from, string to)
        {
            if (!CanAdd()) return;
            var matchFrom = _nodes.SingleOrDefault(n => n.Key == from);
            var matchTo = _nodes.SingleOrDefault(n => n.Key == to);
            if (matchFrom == null || matchTo == null) return;
            matchFrom.AddNeighbour(matchTo);
        }

        /// <summary>
        /// Removes edge from the graph.
        /// </summary>
        /// <param name="from">First vertex of an edge.</param>
        /// <param name="to">Second vertex of an edge.</param>
        public void RemoveEdge(string from, string to)
        {
            if (!CanAdd()) return;
            var matchFrom = _nodes.SingleOrDefault(n => n.Key == from);
            var matchTo = _nodes.SingleOrDefault(n => n.Key == to);
            if (matchFrom == null || matchTo == null) return;
            matchFrom.RemoveNeighbour(matchTo);
        }

        /// <summary>
        /// Returns nodes decoded from binary representation to their object representation matching the one inside graph.
        /// </summary>
        /// <param name="binaryEncodedSolution">Binary encoded nodes.</param>
        /// <returns>Decoded nodes.</returns>
        public ICollection<Node> BinarySolutionAsNodes(bool[] binaryEncodedSolution)
        {
            if (binaryEncodedSolution.Length != TotalNodes) return null;
            HashSet<Node> output = new HashSet<Node>();
            for (int i = 0; i < binaryEncodedSolution.Length; i++)
            {
                if (binaryEncodedSolution[i])
                    output.Add(_nodes[i]);
            }
            return output;
        }

        /// <summary>
        /// Locks graph and assumes its population has completed.
        /// No items can be added to Graph later on.
        /// </summary>
        public void LockGraph()
        {
            _isLocked = true;
        }

        private bool CanAdd()
        {
            return !_isLocked;
        }
    }
}
