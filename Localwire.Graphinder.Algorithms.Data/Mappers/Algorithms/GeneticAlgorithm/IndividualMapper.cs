namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Algorithms.GeneticAlgorithm
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Algorithms.GeneticAlgorithm;
    using Core.Graph;
    using Core.Problems;
    using Entities.Algorithms.GeneticAlgorithm;
    using Entities.Graph;
    using Entities.Problems;
    using Graph;
    using Problems;

    internal static class IndividualMapper
    {
        private static Individual AsDomainModel(this IndividualEntity entity, Graph graph, IProblem problem)
        {
            return new Individual(graph, problem, entity.CurrentSolution, entity.Id); 
        }

        private static IndividualEntity AsEntityModel(this Individual model, GraphEntity graph, ProblemEntity problem)
        {
            return new IndividualEntity
            {
                Id = model.Id,
                Graph = graph,
                Problem = problem,
                CurrentSolution = model.CurrentSolution
            };
        }

        public static IEnumerable<Individual> AsDomainModel(this IEnumerable<IndividualEntity> entities, Graph graph, IProblem problem)
        {
            if (entities == null) return new List<Individual>();
            return entities.Where(e => e != null).Select(e => e.AsDomainModel(graph, problem));
        }

        public static IEnumerable<IndividualEntity> AsEntityModel(this IEnumerable<Individual> models, GraphEntity graph, ProblemEntity problem)
        {
            if (models == null) return new List<IndividualEntity>();
            return models.Where(m => m != null).Select(m => m.AsEntityModel(graph, problem));
        }
    }
}
