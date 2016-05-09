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
        public GetAlgorithmById(IDatabaseConfiguration configuration) : base(configuration)
        {
        }

        public Guid SearchedId { get; set; }

        public async Task<IAlgorithm> QueryAsync()
        {
            ValidateOperationInputs();
            var match = await Context.Algorithms.EagerLoaded()
                .SingleOrDefaultAsync(a => a.Id.Equals(SearchedId));
            return match.AsDomainModelResolved();
        }

        public IAlgorithm Query()
        {
            ValidateOperationInputs();
            return Context.Algorithms.EagerLoaded()
                .SingleOrDefault(a => a.Id.Equals(SearchedId))
                .AsDomainModelResolved();
        }

        protected override void ValidateOperationInputs()
        {
            if (SearchedId.Equals(Guid.Empty))
                throw new ArgumentNullException(nameof(SearchedId));
        }
    }
}
