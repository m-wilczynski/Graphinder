namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Commands
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Base;
    using Core.Algorithms;
    using EntityFramework;
    using Mappers.Algorithms;

    public class AddAlgorithm : SqlServerOperation, ICommandOperation
    {
        public AddAlgorithm(IDatabaseConfiguration configuration) : base(configuration)
        {
        }

        public IAlgorithm Algorithm { get; set; }

        public async Task<bool> ExecuteAsync()
        {
            ValidateOperationInputs();
            var matchingGraph = await Context.Graphs.Include(g => g.Nodes).SingleOrDefaultAsync(g => g.Id.Equals(Algorithm.Graph.Id));
            var resolvedEntity = Algorithm.AsEntityModelResolved(matchingGraph);
            if (resolvedEntity == null)
                 return false;
            Context.Algorithms.Add(resolvedEntity);
            await Context.SaveChangesAsync();
            return true;
        }

        public bool Execute()
        {
            ValidateOperationInputs();
            var matchingGraph = Context.Graphs.Include(g => g.Nodes).SingleOrDefault(g => g.Id.Equals(Algorithm.Graph.Id));
            var resolvedEntity = Algorithm.AsEntityModelResolved(matchingGraph);
            if (resolvedEntity == null)
                return false;
            Context.Algorithms.Add(resolvedEntity);
            Context.SaveChanges();
            return true;
        }

        protected override void ValidateOperationInputs()
        {
            if (Algorithm == null)
                throw new ArgumentNullException(nameof(Algorithm));
        }
    }
}
