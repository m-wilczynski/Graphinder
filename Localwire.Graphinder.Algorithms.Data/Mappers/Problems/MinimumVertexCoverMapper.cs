namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Problems
{
    using Core.Problems;
    using Core.Problems.OptimizationProblems;
    using Entities.Problems;
    using Exceptions;

    internal class MinimumVertexCoverMapper
    {
        public IProblem AsDomainModel(ProblemEntity entity)
        {
            var casted = entity as MinimumVertexCoverEntity;
            if (casted == null)
                throw new InvalidMapperException(entity.GetType(), typeof(MinimumVertexCoverEntity), nameof(AsDomainModel));
            return null;
        }

        public ProblemEntity AsEntityModel(IProblem model)
        {
            var casted = model as MinimumVertexCover;
            if (casted == null)
                throw new InvalidMapperException(model.GetType(), typeof(MinimumVertexCover), nameof(AsEntityModel));
            return null;
        }
    }
}
