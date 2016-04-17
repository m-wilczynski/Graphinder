namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Problems
{
    using System.Collections.Generic;
    using Graph;

    internal abstract class ProblemEntity : BaseEntity
    {
        public ICollection<NodeEntity> CurrentSolution { get; set; }  
    }
}
