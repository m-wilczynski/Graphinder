namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Problems
{
    using Base;
    using Core.Problems;
    using Core.Problems.OptimizationProblems;
    using Entities.Problems;

    internal class MinimumVertexCoverMapper : IProblemMapperFor<MinimumVertexCover, MinimumVertexCoverEntity>
    {
        public IProblem ToDomainModel(ProblemEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public ProblemEntity ToEntityModel(IProblem model)
        {
            throw new System.NotImplementedException();
        }
    }
}
