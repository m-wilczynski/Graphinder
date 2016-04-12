namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Graph
{
    using System.Collections.Generic;

    public class GraphEntity : BaseEntity
    {
        public ICollection<NodeEntity> Nodes { get; set; }
    }
}
