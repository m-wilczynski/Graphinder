namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Commands
{
    using System;
    using System.Threading.Tasks;
    using Base;
    using Core.Graph;
    using EntityFramework;
    using Mappers.Graph;

    public class AddGraph : SqlServerOperation, ICommandOperation
    {
        public AddGraph(IDatabaseConfiguration configuration) : base(configuration)
        {
        }

        public Graph Graph { get; set; }

        public async Task<bool> ExecuteAsync()
        {
            var resolvedEntity = Graph.AsEntityModel();
            if (resolvedEntity == null)
                return false;
            Context.Graphs.Add(resolvedEntity);
            await Context.SaveChangesAsync();
            return true;
        }

        public bool Execute()
        {
            var resolvedEntity = Graph.AsEntityModel();
            if (resolvedEntity == null)
                return false;
            Context.Graphs.Add(resolvedEntity);
            Context.SaveChanges();
            return true;
        }

        protected override void ValidateOperationInputs()
        {
            if (Graph == null)
                throw new ArgumentNullException(nameof(Graph));
        }
    }
}
