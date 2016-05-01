namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Commands
{
    using System;
    using System.Threading.Tasks;
    using Base;
    using Core.Graph;
    using Mappers.Graph;

    public class AddGraph : SqlServerOperation, ICommandOperation
    {
        private Graph _graph;

        public AddGraph(Graph algorithm)
        {
            if (algorithm == null)
                throw new ArgumentNullException(nameof(algorithm));
            _graph = algorithm;
        }

        public async Task<bool> ExecuteAsync()
        {
            var resolvedEntity = _graph.AsEntityModel();
            if (resolvedEntity == null)
                return false;
            Context.Graphs.Add(resolvedEntity);
            await Context.SaveChangesAsync();
            return true;
        }

        public bool Execute()
        {
            var resolvedEntity = _graph.AsEntityModel();
            if (resolvedEntity == null)
                return false;
            Context.Graphs.Add(resolvedEntity);
            Context.SaveChanges();
            return true;
        }
    }
}
