namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Commands
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Core.Algorithms;
    using Mappers.Algorithms;

    public class AddAlgorithm : SqlServerOperation, ICommandOperation
    {
        private IAlgorithm _algorithm;

        public AddAlgorithm(IAlgorithm algorithm)
        {
            if (algorithm == null)
                throw new ArgumentNullException(nameof(algorithm));
            _algorithm = algorithm;
        }

        public async Task<bool> ExecuteAsync()
        {
            var matchingGraph = await Context.Graphs.Include(g => g.Nodes).SingleOrDefaultAsync(g => g.Id.Equals(_algorithm.Graph.Id));
            var resolvedEntity = _algorithm.AsEntityModelResolved(matchingGraph);
            if (resolvedEntity == null)
                 return false;
            Context.Algorithms.Add(resolvedEntity);
            await Context.SaveChangesAsync();
            return true;
        }

        public bool Execute()
        {
            var matchingGraph = Context.Graphs.Include(g => g.Nodes).SingleOrDefault(g => g.Id.Equals(_algorithm.Graph.Id));
            var resolvedEntity = _algorithm.AsEntityModelResolved(matchingGraph);
            if (resolvedEntity == null)
                return false;
            Context.Algorithms.Add(resolvedEntity);
            Context.SaveChanges();
            return true;
        }
    }
}
