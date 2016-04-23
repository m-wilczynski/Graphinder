namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Problems
{
    using System.Collections.Generic;
    using Graph;

    internal abstract class ProblemEntity : BaseEntity
    {
        public GraphEntity Graph { get; set; }
        public virtual ICollection<NodeEntity> CurrentSolution { get; set; }  
    }
}
