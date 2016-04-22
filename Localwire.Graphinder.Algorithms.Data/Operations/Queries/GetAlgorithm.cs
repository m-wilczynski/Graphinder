namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.Algorithms;
    using Mappers.Algorithms;

    public class GetAlgorithm : SqlServerOperation
    {
        public ICollection<IAlgorithm> Query()
        {
            return Context.Algorithms.ToList().Select(a => a.AsDomainModelResolved()).ToList();
        }
    }
}
