namespace Localwire.Graphinder.Algorithms.DataAccess.Problems
{
    using System.Collections.Generic;
    using Core.Graph;
    using EnumMappings.ProblemTypes;
    using Graph;

    public class ProblemEntity : BaseEntity
    {
        public ProblemType ProblemType { get; set; }
        public ICollection<NodeEntity> CurrentSolution { get; set; }  
    }
}
