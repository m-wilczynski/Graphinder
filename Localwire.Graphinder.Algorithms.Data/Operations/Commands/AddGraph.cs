namespace Localwire.Graphinder.Algorithms.DataAccess.Operations.Commands
{
    using System;
    using Core.Graph;
    using Mappers.Graph;

    public class AddGraph : SqlServerOperation
    {
        private Graph _graph;

        public AddGraph(Graph algorithm)
        {
            if (algorithm == null)
                throw new ArgumentNullException(nameof(algorithm));
            _graph = algorithm;
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
