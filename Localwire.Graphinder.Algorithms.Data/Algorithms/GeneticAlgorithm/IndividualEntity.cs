namespace Localwire.Graphinder.Algorithms.DataAccess.Algorithms.GeneticAlgorithm
{
    using Graph;
    using Problems;

    public class IndividualEntity : BaseEntity
    {
        public GraphEntity Graph { get; set; }
        public ProblemEntity Problem { get; set; }
        public bool[] CurrentSolution { get; set; }
    }
}
