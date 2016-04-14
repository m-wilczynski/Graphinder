namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Problems
{
    using System.Collections.Generic;
    using EnumMappings.ProblemTypes;
    using Graph;

    internal class ProblemEntity : BaseEntity
    {
        public ProblemType ProblemType { get; set; }
        public ICollection<NodeEntity> CurrentSolution { get; set; }  
    }
}
