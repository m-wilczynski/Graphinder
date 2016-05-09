namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Queries
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Core.Algorithms;
    using EntityFramework;
    using Mappers.Algorithms;

    public class GetAlgorithms : SqlServerOperation, IQueryManyOperation<IAlgorithm>
    {
        public GetAlgorithms(IDatabaseConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ICollection<IAlgorithm>> QueryAsync()
        {
            ValidateOperationInputs();
            var alghs = await Context.Algorithms.EagerLoaded().ToListAsync();
            return alghs.Select(a => a.AsDomainModelResolved()).ToList();
        }

        public ICollection<IAlgorithm> Query()
        {
            ValidateOperationInputs();
            return Context.Algorithms.EagerLoaded().ToList()
                .Select(a => a.AsDomainModelResolved()).ToList();
        }

        protected override void ValidateOperationInputs()
        {
        }
    }
}
