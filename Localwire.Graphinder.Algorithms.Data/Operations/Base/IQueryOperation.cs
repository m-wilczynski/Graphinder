namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Base
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core;
    using Entities;

    public interface IQueryOperation<TDomain>
    {
        Task<ICollection<TDomain>> QueryAsync();
        ICollection<TDomain> Query();
    }
}
