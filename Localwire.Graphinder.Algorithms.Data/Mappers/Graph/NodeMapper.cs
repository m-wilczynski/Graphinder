namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Graph
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Graph;
    using Entities.Graph;

    internal static class NodeMapper
    {
        public static IEnumerable<Node> AsDomainModel(this IEnumerable<NodeEntity> entities, Graph graph)
        {
            if (entities == null || graph == null) return new List<Node>();

            var output = new List<Node>();

            foreach (var entity in entities.Where(e => e != null).OrderBy(e => e.Position))
            {
                var match = graph.GetNodeOfKey(entity.Key);
                if (match == null)
                    throw new KeyNotFoundException("Node not found in parent graph");
                output.Add(match);
            }
            return output;
        }

        public static IEnumerable<NodeEntity> AsEntityModel(this IEnumerable<Node> models, GraphEntity graph)
        {
            if (models == null || graph == null) return new List<NodeEntity>();

            var nodes = models as IList<Node> ?? models.ToList();
            var counter = 0;
            var dict = nodes.FirstOrDefault(n => n != null).Parent.Nodes.Where(m => m != null)
                .Select(m =>
                {
                    var entity = new NodeEntity
                    {
                        Graph = graph,
                        Id = m.Id,
                        Key = m.Key,
                        Position = counter
                    };
                    counter++;
                    return entity;
                })
                .ToDictionary(m => m.Id, m => m);
            foreach (var model in nodes.Where(m => m != null))
            {
                NodeEntity entity = dict[model.Id];
                entity.Neighbours = new List<NodeEntity>();
                foreach (var ngh in model.Neighbours.Where(ngh => ngh != null))
                {
                    entity.Neighbours.Add(dict[ngh.Id]);
                }
            }
            return dict.Values.ToList();
        }
    }
}
