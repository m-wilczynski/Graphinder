namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Algorithms.GeneticAlgorithm
{
    using Graph;
    using Problems;

    internal class IndividualEntity : BaseEntity
    {
        public GraphEntity Graph { get; set; }
        public ProblemEntity Problem { get; set; }
        public byte[] CurrentSolution { get; set; }
    }
}
