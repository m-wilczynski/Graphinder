namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Problems
{
    using System;
    using Core.Problems;
    using Core.Problems.OptimizationProblems;
    using Entities.Problems;

    public static class GenericProblemMappingResolver
    {
        public static IProblem AsDomainModelResolved(this ProblemEntity entity)
        {
            if (entity is MinimumVertexCoverEntity)
                return ((MinimumVertexCoverEntity) entity).AsDomainModelResolved();

            throw new NotImplementedException("Mapper for provided entity of type" + entity.GetType() +" not found");
        }

        public static ProblemEntity AsEntityModelResolved(this IProblem model)
        {
            if (model is MinimumVertexCover)
                return ((MinimumVertexCover) model).AsEntityModelResolved();

            throw new NotImplementedException("Mapper for provided model of type" + model.GetType() +" not found");
        }
    }
}
