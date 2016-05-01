namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Algorithms
{
    using Graph;
    using Problems;

    internal abstract class AlgorithmEntity : BaseEntity
    {
        public GraphEntity Graph { get; set; }
        public ProblemEntity Problem { get; set; }
        public long TotalProcessorTimeCost { get; set; }
    }
}
