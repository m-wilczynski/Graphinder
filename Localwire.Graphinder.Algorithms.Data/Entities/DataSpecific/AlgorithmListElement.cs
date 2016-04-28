namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.DataSpecific
{
    using System;

    public class AlgorithmListElement : BaseEntity
    {
        public Type AlgorithmType { get; set; }
        public Type ProblemType { get; set; }
        public uint GraphNodesCount { get; set; }
        public uint GraphEdgesCount { get; set; }
        public long CurrentProcessorTime { get; set; }
    }
}
