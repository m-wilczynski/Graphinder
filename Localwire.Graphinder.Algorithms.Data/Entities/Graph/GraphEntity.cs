namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Graph
{
    using System.Collections.Generic;

    internal class GraphEntity : BaseEntity
    {
        public ICollection<NodeEntity> Nodes { get; set; }
    }
}
