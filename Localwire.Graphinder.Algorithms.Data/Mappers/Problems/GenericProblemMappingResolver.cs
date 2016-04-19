namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Problems
{
    using System;
    using Core;
    using Core.Problems;
    using Core.Problems.OptimizationProblems;
    using Entities.Problems;
    using Exceptions;

    internal static class GenericProblemMappingResolver
    {
        public static IProblem AsDomainModelResolved(this ProblemEntity entity)
        {
            if (entity is MinimumVertexCoverEntity)
                return ((MinimumVertexCoverEntity) entity).AsDomainModel();

            throw new MappingNotImplementedException(entity);
        }

        public static ProblemEntity AsEntityModelResolved(this IProblem model)
        {
            if (model is MinimumVertexCover)
                return ((MinimumVertexCover) model).AsEntityModel();

            throw new MappingNotImplementedException(model as BaseModel);
        }
    }
}
