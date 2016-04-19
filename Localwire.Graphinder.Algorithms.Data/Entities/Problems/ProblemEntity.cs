namespace Localwire.Graphinder.Algorithms.DataAccess.Entities.Problems
{
    using System.Collections.Generic;
    using Graph;

    public abstract class ProblemEntity : BaseEntity
    {
        internal GraphEntity Graph { get; set; }
        internal virtual ICollection<NodeEntity> CurrentSolution { get; set; }  
    }
}
