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

        /// <summary>
        /// Creates node with given key
        /// </summary>
        /// <param name="key">Key that ensures node uniqueness</param>
        public Node(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("Node needs valid key!");
            Key = key;
            Neighbours = new HashSet<Node>();
        }

        /// <summary>
        /// Adds neighbouring node
        /// </summary>
        /// <param name="n">New neighbour to add</param>
        public void AddNeighbour(Node n)
        {
            if (n == null || n.Equals(this) || Neighbours.Any(node => node.Equals(n))) return;
            Neighbours.Add(n);
            n.AddNeighbour(this);
        }

        /// <summary>
        /// Removes neighbouring node
        /// </summary>
        /// <param name="n">Neighbour to remove</param>
        public void RemoveNeighbour(Node n)
        {
            if (n == null || n.Equals(this)) return;
            var match = Neighbours.Single(node => node.Equals(n));
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
    }
}
