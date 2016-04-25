namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Base
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQueryManyOperation<TDomain>
    {
        Task<ICollection<TDomain>> QueryAsync();
        ICollection<TDomain> Query();
    }

    public interface IQuerySingleOperation<TDomain>
    {
        Task<TDomain> QueryAsync();
        TDomain Query();
    }
}
