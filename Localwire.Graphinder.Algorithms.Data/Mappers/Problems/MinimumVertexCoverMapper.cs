namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Problems
{
    using System.Linq;
    using Core.Graph;
    using Core.Problems.OptimizationProblems;
    using Entities.Graph;
    using Entities.Problems;
    using Graph;

    internal class MinimumVertexCoverMapper
    {
        public MinimumVertexCover AsDomainModel(MinimumVertexCoverEntity entity, Graph graph = null)
        {
            var problem = new MinimumVertexCover(entity.Id);
            problem.Initialize(graph ?? entity.Graph.AsDomainModel());
            problem.SetNewSolution(entity.CurrentSolution.AsDomainModel().ToList());
            return problem;
        }

        public MinimumVertexCoverEntity AsEntityModel(MinimumVertexCover model, GraphEntity graph = null)
        {
            return new MinimumVertexCoverEntity()
            {
                Id = model.Id,
                Graph = graph ?? model.Graph.AsEntityModel(),
                CurrentSolution = model.CurrentSolution.AsEntityModel().ToList()
            };
        }
    }
}
