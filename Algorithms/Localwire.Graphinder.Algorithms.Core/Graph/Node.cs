namespace Localwire.Graphinder.Core.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents basic node of undirected graph
    /// </summary>
    public class Node : BaseModel
    {
        public readonly HashSet<Node> Neighbours;
        public readonly string Key;
        public readonly Graph Parent;

        /// <summary>
        /// Instantiates node with given key
        /// </summary>
        /// <param name="key">Key that ensures node uniqueness</param>
        /// <param name="parent">Graph of which node is part of.</param>
        public Node(string key, Graph parent, Guid? id = null) : base(id)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("Node needs valid key!");
            if (parent == null) throw new ArgumentNullException(nameof(parent));
            Key = key;
            Neighbours = new HashSet<Node>();
            Parent = parent;
        }

        /// <summary>
        /// Adds neighbouring node. Will fail if not added via <see cref="T:Localwire.Graphinder.Core.Graph.Graph"/>.
        /// </summary>
        /// <param name="node">New neighbour to add</param>
        public void AddNeighbour(Node node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            //Prevent endless circular adding
            if (Neighbours.Contains(node))
                return;
            if (node.Equals(this))
                throw new InvalidOperationException("Attempt to add self as neighbour!");
            if (!CanAddNeighbour(node))
                throw new InvalidOperationException("Neighbour cannot be added!");
            Neighbours.Add(node);
            node.AddNeighbour(this);
        }

        /// <summary>
        /// Removes neighbouring node
        /// </summary>
        /// <param name="node">Neighbour to remove</param>
        public void RemoveNeighbour(Node node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            var match = Neighbours.SingleOrDefault(n => node.Equals(n));
            //Prevent endless circular removing
            if (match == null)
                return;
            if (!CanRemoveNeighbour(node))
                throw new InvalidOperationException("Neighbour cannot be removed!");
            Neighbours.Remove(match);
            match.RemoveNeighbour(this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var casted = obj as Node;
            if (casted == null) return false;
            return casted.Key == Key && casted.Parent == Parent;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        private bool CanAddNeighbour(Node node)
        {
            if (node == null) return false;
            //Check if the same graph, ie. same reference
            //Allow adding only if edge was added by Graph beforehand
            return Parent.Equals(node.Parent) && Parent.ContainsNode(node.Key) && Parent.ContainsEdge(this, node);
        }

        private bool CanRemoveNeighbour(Node node)
        {
            if (node == null) return false;
            return Parent.ContainsNode(node.Key) && !Parent.ContainsEdge(this, node);
        }
    }
}
