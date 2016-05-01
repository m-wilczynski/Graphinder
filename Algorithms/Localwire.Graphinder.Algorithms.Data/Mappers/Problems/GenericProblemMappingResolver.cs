namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Problems
{
    using System;
    using Core;
    using Core.Graph;
    using Core.Problems;
    using Core.Problems.OptimizationProblems;
    using Entities.Graph;
    using Entities.Problems;
    using Exceptions;

    internal static class GenericProblemMappingResolver
    {
        public static IProblem AsDomainModelResolved(this ProblemEntity entity, Graph graph = null)
        {
            if (entity is MinimumVertexCoverEntity)
                return ((MinimumVertexCoverEntity) entity).AsDomainModel(graph);

            throw new MappingNotImplementedException(entity);
        }

        public static ProblemEntity AsEntityModelResolved(this IProblem model, GraphEntity graph = null)
        {
            if (model is MinimumVertexCover)
                return ((MinimumVertexCover) model).AsEntityModel(graph);

            throw new MappingNotImplementedException(model as BaseModel);
        }
    }
}
