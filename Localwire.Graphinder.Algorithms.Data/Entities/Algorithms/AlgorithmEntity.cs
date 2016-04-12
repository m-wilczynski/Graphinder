namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Algorithms
{
    using Graph;
    using Problems;

    public abstract class AlgorithmEntity : BaseEntity
    {
        public GraphEntity Graph { get; set; }
        public ProblemEntity Problem { get; set; }
        public long TotalProcessorTimeCost { get; set; }
    }
}
