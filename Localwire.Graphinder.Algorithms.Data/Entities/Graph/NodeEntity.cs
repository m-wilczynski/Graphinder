namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Graph
{
    using System.Collections.Generic;

    public class NodeEntity : BaseEntity
    {
        public string Key { get; set; }
        public GraphEntity Graph { get; set; }
        public ICollection<NodeEntity> Neighbours { get; set; } 
    }
}
