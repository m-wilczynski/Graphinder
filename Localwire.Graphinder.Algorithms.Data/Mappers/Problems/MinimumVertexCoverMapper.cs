namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Problems
{
    using Base;
    using Core.Problems;
    using Core.Problems.OptimizationProblems;
    using Entities.Problems;
    using Exceptions;

    internal class MinimumVertexCoverMapper : IProblemMapperFor<MinimumVertexCover, MinimumVertexCoverEntity>
    {
        public IProblem ToDomainModel(ProblemEntity entity)
        {
            var casted = entity as MinimumVertexCoverEntity;
            if (casted == null)
                throw new InvalidMapperException(entity.GetType(), typeof(MinimumVertexCoverEntity), nameof(ToDomainModel));
            return null;
        }

        public ProblemEntity ToEntityModel(IProblem model)
        {
            var casted = model as MinimumVertexCover;
            if (casted == null)
                throw new InvalidMapperException(model.GetType(), typeof(MinimumVertexCover), nameof(ToEntityModel));
            return null;
        }
    }
}
