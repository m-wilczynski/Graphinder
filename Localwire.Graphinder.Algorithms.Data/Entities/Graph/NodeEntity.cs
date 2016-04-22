namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Graph
{
    using System.Collections.Generic;

    internal class NodeEntity : BaseEntity
    {
        public string Key { get; set; }
        public GraphEntity Graph { get; set; }
        public virtual ICollection<NodeEntity> Neighbours { get; set; } 
    }
}
