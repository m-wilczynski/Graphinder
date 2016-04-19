namespace Localwire.Graphinder.Algorithms.DataAccess.Mappers.Algorithms.GeneticAlgorithm
{
    using Core.Algorithms.GeneticAlgorithm;
    using Entities.Algorithms.GeneticAlgorithm;
    using Graph;
    using Problems;

    internal static class IndividualMapper
    {
        public static Individual AsDomainModel(this IndividualEntity entity, GeneticAlgorithm parent = null)
        {
            return new Individual(
                parent == null ? entity.Graph.AsDomainModel() : parent.Graph,
                parent == null ? entity.Problem.AsDomainModelResolved() : parent.Problem,
                entity.CurrentSolution,
                entity.Id); 
        }

        public static IndividualEntity AsEntityModel(this Individual model, GeneticAlgorithmEntity parent = null)
        {
            return new IndividualEntity
            {
                Id = model.Id,
                Graph = parent == null ? model.Graph.AsEntityModel() : parent.Graph,
                Problem = parent == null ? model.Problem.AsEntityModelResolved() : parent.Problem,
                CurrentSolution = model.CurrentSolution
            };
        }
    }
}
