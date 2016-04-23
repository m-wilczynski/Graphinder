namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Queries
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Core.Algorithms;
    using Mappers.Algorithms;

    public class GetAlgorithm : SqlServerOperation
    {
        public ICollection<IAlgorithm> Query()
        {
            return Context.Algorithms
                .Include(a => a.Graph)
                .Include(a => a.Problem)
                .Include(a => a.Graph.Nodes)
                .Include(a => a.Graph.Nodes.Select(n => n.Neighbours))
                .Include(a => a.Problem.Graph)
                .Include(a => a.Problem.CurrentSolution)
                .ToList().Select(a => a.AsDomainModelResolved()).ToList();
        }
    }
}
