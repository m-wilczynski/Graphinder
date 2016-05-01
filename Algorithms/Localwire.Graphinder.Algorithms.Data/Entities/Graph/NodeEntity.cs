namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Graph
{
    using System.Collections.Generic;

    internal class NodeEntity : BaseEntity
    {
        public string Key { get; set; }
        //Position in underlying list of Graph to ensure order on deserialization
        public int Position { get; set; }
        public GraphEntity Graph { get; set; }
        public ICollection<NodeEntity> Neighbours { get; set; } 
    }
}
