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
            List<EdgeMapping> edgesToAdd = new List<EdgeMapping>();

            var graph = new Graph(entity.Id);
            foreach (var node in entity.Nodes)
            {
                graph.AddNode(node.Key, node.Id);
                edgesToAdd.AddRange(node.Neighbours
                    .Where(ngh => ngh != null)
                    .Select(ngh => new EdgeMapping { FromKey = node.Key, ToKey = ngh.Key }));
            }
            foreach (var edge in edgesToAdd.Where(edge => !graph.ContainsEdge(edge.FromKey, edge.ToKey)))
            {
                graph.AddEdge(edge.FromKey, edge.ToKey);
            }

            return graph;
        }

        public static GraphEntity AsEntityModel(this Graph model)
        {
            var graph = new GraphEntity { Id = model.Id };
            graph.Nodes = model.Nodes.AsEntityModel(graph).ToList();
            return graph;
        }

        private class EdgeMapping
        {
            public string FromKey { get; set; }
            public string ToKey { get; set; }
        }
    }
}
