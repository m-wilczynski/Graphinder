namespace Localwire.Graphinder.Core.Graph
{
    using System;

    public class Edge
    {
        public readonly Node From;
        public readonly Node To;

        public Edge(Node from, Node to)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));
            if (to == null)
                throw new ArgumentNullException(nameof(to));
            if (!CanConnect(from, to))
                throw new ArgumentException("Nodes cannot be connected due to mismatched criterias!");
            From = from;
            To = to;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var casted = obj as Edge;
            if (casted == null) return false;
            return (casted.From.Equals(From) && casted.To.Equals(To) ||
                   casted.From.Equals(To) && casted.To.Equals(From)) &&
                   casted.From.Parent.Equals(From.Parent);
        }

        public override int GetHashCode()
        {
            //TODO: High hashcode collision possibility. Another way round?
            // Should suffice for HashSet<T>.Contains though...
            int hash = 17;
            hash += From.GetHashCode()*23;
            hash += To.GetHashCode()*23;
            return hash;
        }

        private bool CanConnect(Node from, Node to)
        {
            if (from == null || to == null)
                return false;
            if (from.Parent != to.Parent)
                return false;
            if (!from.Parent.ContainsNode(from.Key) || !to.Parent.ContainsNode(to.Key))
                return false;
            return true;
        }
    }
}
