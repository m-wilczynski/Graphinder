namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Graph
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Graph;
    using Entities.Graph;

    internal static class NodeMapper
    {
        public static Node AsDomainModel(this NodeEntity entity)
        {
            return null;
        }

        public static IEnumerable<Node> AsDomainModel(this IEnumerable<NodeEntity> entities)
        {
            return entities.Where(e => e != null).Select(AsDomainModel);
        } 

        public static NodeEntity AsEntityModel(this Node model)
        {
            return null;
        }

        public static IEnumerable<NodeEntity> AsEntityModel(this IEnumerable<Node> models)
        {
            return models.Where(m => m != null).Select(AsEntityModel);
        } 
    }
}
