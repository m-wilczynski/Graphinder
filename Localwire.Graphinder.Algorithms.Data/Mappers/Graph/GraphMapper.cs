namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Graph
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Graph;
    using Entities.Graph;

    internal static class GraphMapper
    {
        public static Graph AsDomainModel(this GraphEntity entity)
        {
            var graph = new Graph(entity.Nodes.AsDomainModel(), entity.Id);
            graph.RebuildNeighbourhood();
            return graph;
        }

        public static GraphEntity AsEntityModel(this Graph model)
        {
            return new GraphEntity
            {
                Id = model.Id,
                DateCreated = model.DateCreated,
                Nodes = model.Nodes.AsEntityModel().ToList()
            };
        }

        private static void RebuildNeighbourhood(this Graph model)
        {
            foreach (var node in model.Nodes)
            {
                foreach (var ngh in node.Neighbours)
                {
                    if (model.ContainsEdge(node, ngh)) continue;
                    model.AddEdge(node.Key, ngh.Key);
                }
            }
        }
    }
}
