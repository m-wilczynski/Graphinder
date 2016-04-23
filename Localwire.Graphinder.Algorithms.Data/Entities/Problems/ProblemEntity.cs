namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Problems
{
    using Graph;

    internal abstract class ProblemEntity : BaseEntity
    {
        public GraphEntity Graph { get; set; }
        public byte[] CurrentSolution { get; set; }  
    }
}
