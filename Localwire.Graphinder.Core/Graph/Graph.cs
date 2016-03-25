namespace Localwire.Graphinder.Core.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Helpers;
    using Exceptions;
    using Helpers;

    /// <summary>
    /// Represents undirected graph data struture.
    /// </summary>
    public class Graph : ISelfValidable
    {
        private bool _isLocked;
        private List<Node> _nodes;
        //TODO: Redundancy vs performance, eh?
        private readonly HashSet<string> _nodeKeys;
        private readonly HashSet<Edge> _edges; 
        private readonly Random _random = new Random();
        private readonly NodeGenerator _nodeGenerator = new NodeGenerator();
        private Stack<int> _randomNodeIndexes = new Stack<int>();

        /// <summary>
        /// Instantiates undirected graph.
        /// </summary>
        public Graph()
        {
            _nodes = new List<Node>();
            _nodeKeys = new HashSet<string>();
            _edges = new HashSet<Edge>();
        }

        /// <summary>
        /// Instantiates undirected graph based on key collection.
        /// </summary>
        /// <param name="nodes">Collection of nodes' keys.</param>
        public Graph(IEnumerable<string> nodes) : this()
        {
            if (nodes == null)
                throw new ArgumentNullException(nameof(nodes));
            foreach (var element in nodes.Where(n => n != null && _nodes.All(node => node.Key != n)))
                AddNode(element);
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
        /// Returns random node from graph
        /// </summary>
        /// <returns>Random node</returns>
        public Node GetRandomNode()
        {
            //If sequence of available, preselected, random nodes is empty, refill it
            lock (_randomNodeIndexes)
            {
                if (_randomNodeIndexes.Count <= 0)
                    _randomNodeIndexes = new Stack<int>(Enumerable.Range(0, _nodes.Count).OrderBy(r => _random.Next()));
                return _nodes[_randomNodeIndexes.Pop()];
            }
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
        /// Total edges in graph.
        /// </summary>
        public int TotalEdges
        {
            get { return _edges.Count; }
        }
        
        /// <summary>
        /// Fills graph with randomly generated data based on seleceted parameters.
        /// </summary>
        /// <param name="nodesCount">Amount of nodes to generate</param>
        /// <param name="maxNeighbours">Maximum number of neighbours per node</param>
        public void FillGraphRandomly(uint nodesCount, uint maxNeighbours)
        {
            if (!CanAdd())
                throw new DataStructureLockedException("Filling graph with random nodes", GetType());
            MaxNeigbhours = maxNeighbours;
            _nodeGenerator.ProvideNodeCollection(this, nodesCount, maxNeighbours);
            LockGraph();
        }

        //TODO: Expensive unless Dictionary of nodes is introduced
        /// <summary>
        /// Adds node to the graph.
        /// </summary>
        /// <param name="key">Key representing node to be added</param>
        public Node AddNode(string key)
        {
            if (!CanAdd())
                throw new DataStructureLockedException("Adding node to graph", GetType()); 
            if (ContainsNode(key))
                throw new InvalidOperationException("Attempt to add duplicate node!");
            var node = new Node(key, this);
            _nodes.Add(node);
            _nodeKeys.Add(key);
            return node;
        }

        //TODO: Expensive unless Dictionary of nodes is introduced
        /// <summary>
        /// Removes node from the graph.
        /// </summary>
        /// <param name="key">Key representing node to be added</param>
        public void RemoveNode(string key)
        {
            if (!CanAdd()) 
                throw new DataStructureLockedException("Removing node from graph", GetType());
            //TODO: Find index of match for O(1) access, instead of iterating over twice
            var match = _nodes.SingleOrDefault(n => n.Key == key);
            if (match == null) 
                throw new InvalidOperationException("Attempt to remove nonexistent node!");
            //Remove relations with other nodes
            foreach (var ngh in match.Neighbours.ToList())
            {
                _edges.Remove(new Edge(ngh, match));
                match.RemoveNeighbour(ngh);
            }
            //Remove node
            _nodes.Remove(match);
            _nodeKeys.Remove(key);
        }

        //TODO: Expensive unless Dictionary of nodes is introduced
        /// <summary>
        /// Adds edge to the graph.
        /// </summary>
        /// <param name="from">First vertex of an edge.</param>
        /// <param name="to">Second vertex of an edge.</param>
        public void AddEdge(string from, string to)
        {
            if (!CanAdd())
                throw new DataStructureLockedException("Adding edge to graph", GetType());
            var matchFrom = _nodes.SingleOrDefault(n => n.Key == from);
            var matchTo = _nodes.SingleOrDefault(n => n.Key == to);
            if (matchFrom == null || matchTo == null)
                throw new InvalidOperationException("Attempt to connect nonexistent node(-s)!");
            var edge = new Edge(matchFrom, matchTo);
            if (_edges.Contains(edge))
                throw new InvalidOperationException("Attempt to add duplicate edge!");
            _edges.Add(edge);
            try
            {
                matchFrom.AddNeighbour(matchTo);
            }
            catch
            {
                //Rollback
                RemoveEdge(from, to);
            }
        }

        //TODO: Expensive unless Dictionary of nodes is introduced
        /// <summary>
        /// Removes edge from the graph.
        /// </summary>
        /// <param name="from">First vertex of an edge.</param>
        /// <param name="to">Second vertex of an edge.</param>
        public void RemoveEdge(string from, string to)
        {
            if (!CanAdd())
                throw new DataStructureLockedException("Removing edge from graph", GetType());
            var matchFrom = _nodes.SingleOrDefault(n => n.Key == from);
            var matchTo = _nodes.SingleOrDefault(n => n.Key == to);
            if (matchFrom == null || matchTo == null)
                throw new InvalidOperationException("Attempt to disconnect nonexistent nodes!");
            _edges.Remove(new Edge(matchFrom, matchTo));
            matchFrom.RemoveNeighbour(matchTo);
        }

        /// <summary>
        /// Returns nodes decoded from binary representation to their object representation matching the one inside graph.
        /// </summary>
        /// <param name="binaryEncodedSolution">Binary encoded nodes.</param>
        /// <returns>Decoded nodes.</returns>
        public ICollection<Node> BinarySolutionAsNodes(bool[] binaryEncodedSolution)
        {
            if (binaryEncodedSolution == null)
                throw new ArgumentNullException(nameof(binaryEncodedSolution));
            if (binaryEncodedSolution.Length != TotalNodes)
                throw new InvalidOperationException("Binary encoded solution doesn't match total graph nodes!");
            HashSet<Node> output = new HashSet<Node>();
            for (int i = 0; i < binaryEncodedSolution.Length; i++)
            {
                if (binaryEncodedSolution[i])
                    output.Add(_nodes[i]);
            }
            return output;
        }

        /// <summary>
        /// Locks graph and assumes populating process has completed.
        /// No items can be added to Graph later on.
        /// </summary>
        public void LockGraph()
        {
            _isLocked = true;
        }

        /// <summary>
        /// Check if graph contains node of given key.
        /// </summary>
        /// <param name="key">Node key to look for</param>
        /// <returns></returns>
        public bool ContainsNode(string key)
        {
            return _nodeKeys.Contains(key);
        }

        /// <summary>
        /// Checks if graph contains edge connecting given nodes.
        /// </summary>
        /// <param name="from">First vertex of an edge.</param>
        /// <param name="to">Second vertex of an edge.</param>
        /// <returns></returns>
        public bool ContainsEdge(Node from, Node to)
        {
            return _edges.Contains(new Edge(from, to));
        }

        /// <summary>
        /// Decides whether graph is locked for any other addition/removal.
        /// If true, graph is still under building and modification is allowed.
        /// If false, graph have completed building and is from now on locked for any modification.
        /// </summary>
        /// <returns></returns>
        public bool CanAdd()
        {
            return !_isLocked;
        }
    }
}
