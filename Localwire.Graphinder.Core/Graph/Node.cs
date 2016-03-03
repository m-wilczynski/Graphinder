namespace Localwire.Graphinder.Core.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class representing basic node of undirected graph
    /// </summary>
    public class Node
    {
        public readonly HashSet<Node> Neighbours;
        public readonly string Key;
        public readonly Graph Parent;

        /// <summary>
        /// Creates node with given key
        /// </summary>
        /// <param name="key">Key that ensures node uniqueness</param>
        /// <param name="parent">Graph of which node is part of.</param>
        public Node(string key, Graph parent)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("Node needs valid key!");
            if (parent == null) throw new ArgumentNullException(nameof(parent));
            Key = key;
            Neighbours = new HashSet<Node>();
            Parent = parent;
        }

        /// <summary>
        /// Adds neighbouring node
        /// </summary>
        /// <param name="node">New neighbour to add</param>
        public void AddNeighbour(Node node)
        {
            if (node == null || node.Equals(this) || Neighbours.Contains(node)) return;
            if (!CanAddNeighbour(node)) throw new InvalidOperationException("Neighbour cannot be added!");
            Neighbours.Add(node);
            node.AddNeighbour(this);
        }

        /// <summary>
        /// Removes neighbouring node
        /// </summary>
        /// <param name="n">Neighbour to remove</param>
        public void RemoveNeighbour(Node n)
        {
            if (n == null || n.Equals(this)) return;
            var match = Neighbours.SingleOrDefault(node => node.Equals(n));
            if (match == null) return;
            Neighbours.Remove(match);
            match.RemoveNeighbour(this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var casted = obj as Node;
            if (casted == null) return false;
            return casted.Key == Key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        /// <summary>
        /// Determines whether new neighbour actually belongs to same graph.
        /// </summary>
        /// <param name="node">Node to add.</param>
        /// <returns></returns>
        public bool CanAddNeighbour(Node node)
        {
            if (node == null) return false;
            //Check if the same graph, ie. same reference
            //Allow adding only if edge was added by Graph beforehand
            return Parent.Equals(node.Parent) && Parent.ContainsNode(node.Key) && Parent.ContainsEdge(this, node);
        }
    }
}
