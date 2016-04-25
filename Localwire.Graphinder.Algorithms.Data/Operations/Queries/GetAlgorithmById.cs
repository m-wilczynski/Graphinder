namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Queries
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Core.Algorithms;
    using EntityFramework;
    using Mappers.Algorithms;

    public class GetAlgorithmById : SqlServerOperation, IQuerySingleOperation<IAlgorithm>
    {
        public Guid SearchedId { get; set; }

        public async Task<IAlgorithm> QueryAsync()
        {
            var match = await Context.Algorithms.EagerLoaded()
                .SingleOrDefaultAsync(a => a.Id.Equals(SearchedId));
            return match.AsDomainModelResolved();
        }

        public IAlgorithm Query()
        {
            return Context.Algorithms.EagerLoaded()
                .SingleOrDefault(a => a.Id.Equals(SearchedId))
                .AsDomainModelResolved();
        }
    }
}
